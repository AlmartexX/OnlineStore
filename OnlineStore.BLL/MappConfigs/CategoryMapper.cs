using AutoMapper;
using OnlineStore.BLL.DTO;
using OnlineStore.BLL.MappConfigs.Interfaces;
using OnlineStore.DAL.Entities;

namespace OnlineStore.BLL.MappConfigs
{
    public class CategoryMapper : ICategoryMapper
    {
        private readonly IMapper _mapper;
        public CategoryMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public CategoryDTO MapToDTO(Category category)
        {
            return _mapper.Map<CategoryDTO>(category);
        }

        public Category MapToEntity(CategoryDTO categoryDTO, Category category)
        {
            return _mapper.Map(categoryDTO, category);
        }

        public Category MapToEntity(CreateCategoryDTO newCategoryDto)
        {
            return _mapper.Map<Category>(newCategoryDto);
        }
    }
}
