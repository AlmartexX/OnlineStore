using OnlineStore.BLL.DTO;

namespace OnlineStore.BLL.Services.Interfaces
{
    public interface IOrderService
    {
        Task<CreateOrderDto> CreateOrderAsync(CreateOrderDto orderDto, CancellationToken cancellationToken);
        Task<IEnumerable<OrderDTO>> GetOrdersAsync(PaginationSettingsDTO paginationSettings, CancellationToken cancellationToken);
        Task<IEnumerable<OrderDto>> GetOrdersByIdAsync(int id, PaginationSettingsDTO paginationSettings, CancellationToken cancellationToken);
        Task<OrderDto> GerOrderByIdWithOrderItemAsync(int id, CancellationToken cancellationToken);
    }
}
