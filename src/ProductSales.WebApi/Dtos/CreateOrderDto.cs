namespace ProductSales.WebApi.Dtos
{
    public record CreateOrderDto(OrderItem[] Orders, string Address, string Email);
}
