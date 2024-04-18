using OnlineStore.BLL.DTO;
using OnlineStore.BLL.DTO.Order;

namespace OnlineStore.BLL.Services.Interfaces
{
    public interface IOrderService
    {
        Task<CreateOrderDto> CreateOrderAsync(CreateOrderDto orderDto, CancellationToken cancellationToken);

        Task<IEnumerable<OrderDto>> GetOrdersByUserIdAsync(int userId, PaginationSettingsDTO paginationSettings,
            CancellationToken cancellationToken);
        Task<OrderDto> GerOrderByIdWithOrderItemAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<OrderDto>> GetOrdersAsync(PaginationSettingsDTO paginationSettings, CancellationToken cancellationToken);

    }
}
