using OnlineStore.BLL.DTO;
using OnlineStore.DAL.Settings;

namespace OnlineStore.BLL.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategoriesAsync(PaginationSettings paginationSettings, CancellationToken cancellationToken);
        Task<CategoryDTO> GetCategoryByIdAsync(int? id, CancellationToken cancellationToken);
        Task<CreateCategoryDTO> CreateCategoryAsync(CreateCategoryDTO newCategory, CancellationToken cancellationToken);
        Task<CategoryDTO> UpdateCategoryAsync(CategoryDTO categoryDTO, int? id, CancellationToken cancellationToken);
        Task<(bool, string)> DeleteCategoryAsync(int? id, CancellationToken cancellationToken);
    }
}
