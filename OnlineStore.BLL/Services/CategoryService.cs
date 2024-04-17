using AutoMapper;
using Microsoft.Extensions.Logging;
using OnlineStore.BLL.DTO;
using OnlineStore.BLL.MappConfigs.Interfaces;
using OnlineStore.BLL.Services.Interfaces;
using OnlineStore.DAL.Repositories.Interfaces;
using OnlineStore.DAL.Repositories.UnitOfWork;
using OnlineStore.DAL.Settings;
using static OnlineStore.BLL.Exceptions.ValidationException;

namespace OnlineStore.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICategoryMapper _categoryMapper;
        private readonly IPaginationSettingsMapper _pagerMapper;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICategoryMapper categoryMapper,
            IPaginationSettingsMapper pagerMapper,
            ILogger<CategoryService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _categoryMapper = categoryMapper;
            _pagerMapper = pagerMapper;
            _logger = logger;
        }

        public async Task<CreateCategoryDTO> CreateCategoryAsync(CreateCategoryDTO newCategory, CancellationToken cancellationToken)
        {
            _logger.LogInformation("--> Category started added process!");
            
            var category = _categoryMapper.MapToEntity(newCategory);
            await _unitOfWork.Categories.AddAsync(category, cancellationToken);
            _logger.LogInformation("--> Category added!");

            return newCategory;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync(PaginationSettingsDTO paginationSettings, CancellationToken cancellationToken )
        {
            var paginationSettingsEntity = _pagerMapper.MapToEntity(paginationSettings);

            var сategories = await _unitOfWork.Categories.GetAllAsync(paginationSettingsEntity, cancellationToken);

            return сategories.Select(category => _categoryMapper.MapToDTO(category));
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int? id, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id.Value, cancellationToken);
            if (category == null)
            {
                throw new NotFoundException("No categories with this id in database");
            }

            return _categoryMapper.MapToDTO(category);
        }
        
        public async Task<CategoryDTO> UpdateCategoryAsync(CategoryDTO categoryDTO, int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("--> Category started updated process!");

            var existingCategory = await _unitOfWork.Categories.GetByIdAsync(id, cancellationToken);
            if (existingCategory == null)
            {
                throw new NotFoundException("No categories with this id in database");
            }

            _categoryMapper.MapToEntity(categoryDTO, existingCategory);
            await _unitOfWork.Categories.UpdateAsync(id, existingCategory, cancellationToken);
            _logger.LogInformation("--> Category updateed!");

            return categoryDTO;
        }

        public async Task<(bool, string)> DeleteCategoryAsync(int? id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("--> Category started deleted process!");

            var category = await _unitOfWork.Categories.GetByIdAsync(id.Value, cancellationToken);
            if (category == null)
            {
                throw new NotFoundException("No categories with this id in database");
            }

            await _unitOfWork.Categories.DeleteAsync(id.Value, cancellationToken);
            _logger.LogInformation("--> Category deleted!");

            return (true, "Category got deleted.");
        }
    }
}
