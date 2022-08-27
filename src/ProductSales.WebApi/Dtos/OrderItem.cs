using System;

namespace ProductSales.WebApi.Dtos
{
    public record OrderItem(Guid ProductId, int Count);
}
