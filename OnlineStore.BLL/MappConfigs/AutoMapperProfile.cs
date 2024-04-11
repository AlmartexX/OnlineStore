using AutoMapper;
using OnlineStore.BLL.DTO;
using OnlineStore.DAL.Entities;

namespace OnlineStore.BLL.MappConfigs
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<CreateProductDTO, Product>();
        }
    }
}
