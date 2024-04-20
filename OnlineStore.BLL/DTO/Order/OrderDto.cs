using OnlineStore.BLL.DTO.OrderItem;

namespace OnlineStore.BLL.DTO.Order
{
    public record OrderDto(DateTime CreatedAt, int userId, List<OrderItemDto> OrderItemDtos);
}
