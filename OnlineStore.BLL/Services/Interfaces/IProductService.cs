
using OnlineStore.BLL.DTO;
using OnlineStore.DAL.Settings;

namespace OnlineStore.BLL.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProductsAsync(PaginationSettings paginationSettings, CancellationToken cancellationToken);
        Task<ProductDTO> GetProductByIdAsync(int? id, CancellationToken cancellationToken);
        Task<ProductDTO> GetProductByCategoryAsync(string categoryName, CancellationToken cancellationToken);
        Task<ProductDTO> CreateProductAsync(ProductDTO productDTO, CancellationToken cancellationToken);
        Task<ProductDTO> UpdateProductAsync(ProductDTO productDTO, int? id, CancellationToken cancellationToken);
        Task<(bool, string)> DeleteProductAsync(int? id, CancellationToken cancellationToken);
    }
}
