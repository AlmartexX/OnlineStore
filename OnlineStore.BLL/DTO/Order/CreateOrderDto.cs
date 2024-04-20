namespace OnlineStore.BLL.DTO.Order
{
    public record CreateOrderDto(DateTime CreatedAt, int userId, List<OrderItemDto> ordersDtos);
}
