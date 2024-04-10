using AutoMapper;
using Microsoft.Extensions.Logging;
using OnlineStore.BLL.DTO;
using OnlineStore.BLL.MappConfigs.Interfaces;
using OnlineStore.BLL.Services.Interfaces;
using OnlineStore.BLL.Vallidation.Interfaces;
using OnlineStore.DAL.Repositories.Interfaces;

namespace OnlineStore.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ICategoryMapper _categoryMapper;
        private readonly ILogger<CategoryService> _logger;
        private readonly IValidationPipelineBehavior<CreateCategoryDTO, CreateCategoryDTO> _createCategoryValidator;
        public CategoryService(
            ICategoryRepository categoryRepository,
            IMapper mapper,
            ICategoryMapper categoryMapper,
            ILogger<CategoryService> logger,
            IValidationPipelineBehavior<CreateCategoryDTO, CreateCategoryDTO> createCategoryValidator)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _categoryMapper = categoryMapper;
            _logger = logger;
            _createCategoryValidator = createCategoryValidator;
        }

        public async Task<CreateCategoryDTO> CreateCategoryAsync(CreateCategoryDTO newCategory)
        {
            _logger.LogInformation("--> Category started added process!");

            return await _createCategoryValidator.Process(newCategory, async () =>
            {
                var category = _categoryMapper.MapToEntity(newCategory);
                await _categoryRepository.AddAsync(category);
                _logger.LogInformation("--> Category added!");

                return newCategory;
            });
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            var сategories = await _categoryRepository.GetAllAsync();

            return сategories.Select(category => _categoryMapper.MapToDTO(category));
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int? id)
        {
            var category = await _categoryRepository.GetByIdAsync(id.Value);
            if (category == null)
            {
                throw new NotFoundException("No records with this id in database");
            }

            return _categoryMapper.MapToDTO(category);
        }
        
        public async Task<CategoryDTO> UpdateCategoryAsync(CategoryDTO categoryDTO, int? id)
        {
            _logger.LogInformation("--> Category started updated process!");

            var existingCategory = await _categoryRepository.GetByIdAsync(id.Value);
            _categoryMapper.MapToEntity(categoryDTO, existingCategory);
            await _categoryRepository.UpdateAsync(existingCategory);
            _logger.LogInformation("--> Category updateed!");

            return categoryDTO;
        }

        public async Task<(bool, string)> DeleteCategoryAsync(int? id)
        {
            _logger.LogInformation("--> Category started deleted process!");

            var category = await _categoryRepository.GetByIdAsync(id.Value);
            await _categoryRepository.DeleteAsync(id.Value);
            _logger.LogInformation("--> Category deleted!");

            return (true, "Category got deleted.");
        }
    }
}
