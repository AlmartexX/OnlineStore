using OnlineStore.BLL.DTO;

namespace OnlineStore.BLL.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategoriesAsync(PaginationSettingsDTO paginationSettings, CancellationToken cancellationToken);
        Task<CategoryDTO> GetCategoryByIdAsync(int? id, CancellationToken cancellationToken);
        Task<CreateCategoryDTO> CreateCategoryAsync(CreateCategoryDTO newCategory, CancellationToken cancellationToken);
        Task<CategoryDTO> UpdateCategoryAsync(CategoryDTO categoryDTO, int? id, CancellationToken cancellationToken);
        Task<(bool, string)> DeleteCategoryAsync(int? id, CancellationToken cancellationToken);
    }
}
