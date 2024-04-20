using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using OnlineStore.BLL.DTO;
using OnlineStore.BLL.DTO.Order;
using OnlineStore.BLL.Services.Interfaces;
using OnlineStore.DAL.Entities;
using OnlineStore.DAL.Repositories.UnitOfWork;

namespace OnlineStore.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateOrderDto> CreateOrderAsync(CreateOrderDto orderDto, CancellationToken cancellationToken)
        {
            var order = new Order()
            {
                UserId = orderDto.userId,
                CreationDate = orderDto.CreatedAt,
            };

            await _repository.Orders.AddAsync(order);

            foreach (var item in orderDto.ordersDtos)
            {
                var orderItem = new OrderItem()
                {
                    OrderId = order.Id,
                    ProductId = item.ProductId,
                };

                await _repository.OrderItems.AddAsync(orderItem);
            }

            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CreateOrderDto>(order);
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersByUserIdAsync(int userId, PaginationSettingsDTO paginationSettings, CancellationToken cancellationToken)
        {
           return await _repository.Orders.GetAllOrdersByUserId(userId, paginationSettings, cancellationToken);
        }

        public async Task<OrderDto> GerOrderByIdWithOrderItemAsync(int id, CancellationToken cancellationToken)
        {
            return await _repository.Orders.GerOrderByIdWithOrderItem(x => x.Id == id, cancellationToken)
                .Select(order => _mapper.Map<OrderDto>(order))
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersAsync(PaginationSettingsDTO paginationSettings, CancellationToken cancellationToken)
        {
           return await _repository.Orders.GetOrdersAsync(paginationSettings, cancellationToken)
               .Select(order => _mapper.Map<OrderDto>(order))
               .ToListAsync(cancellationToken);
        }
    }
}
