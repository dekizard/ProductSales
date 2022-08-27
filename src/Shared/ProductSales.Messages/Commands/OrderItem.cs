namespace ProductSales.Messages.Commands
{
    public interface OrderItem
    {
        public Guid ProductId { get; }
        public int Count { get; }
    }
}
