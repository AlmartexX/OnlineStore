using OnlineStore.BLL.DTO;
using OnlineStore.DAL.Entities;

namespace OnlineStore.BLL.MappConfigs.Interfaces
{
    public interface IProductMapper
    {
        ProductDTO MapToDTO(Product product);
        Product MapToEntity(ProductDTO newProductDto);
        Product MapToEntity(CreateProductDTO newProductDto);
    }
}
