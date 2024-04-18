using AutoMapper;
using OnlineStore.BLL.DTO;
using OnlineStore.BLL.DTO.Order;
using OnlineStore.BLL.DTO.User;
using OnlineStore.DAL.Entities;
using OnlineStore.DAL.Settings;

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
            CreateMap<PaginationSettings, PaginationSettingsDTO>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
        }
    }
}
