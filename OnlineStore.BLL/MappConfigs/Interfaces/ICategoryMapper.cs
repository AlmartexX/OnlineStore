using OnlineStore.BLL.DTO;
using OnlineStore.DAL.Entities;

namespace OnlineStore.BLL.MappConfigs.Interfaces
{
    public interface ICategoryMapper
    {
        CategoryDTO MapToDTO(Category category);
        Category MapToEntity(CategoryDTO category);
        Category MapToEntity(CategoryDTO categoryDTO, Category category);
        Category MapToEntity(CreateCategoryDTO newCategoryDto);
    }
}
