using AutoMapper;
using OnlineStore.BLL.DTO;
using OnlineStore.BLL.MappConfigs.Interfaces;
using OnlineStore.DAL.Entities;

namespace OnlineStore.BLL.MappConfigs
{
    public class ProductMapper : IProductMapper
    {
        private readonly IMapper _mapper;
        public ProductMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ProductDTO MapToDTO(Product product)
        {
            return _mapper.Map<ProductDTO>(product);
        }

        public Product MapToEntity(CreateProductDTO newProductDto)
        {
            return _mapper.Map<Product>(newProductDto);
        }
    }
}
