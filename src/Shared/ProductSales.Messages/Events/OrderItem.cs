namespace ProductSales.Messages.Events
{
    public interface OrderItem
    {
        public string ProductName { get; }
        public int Count { get; }
        public decimal? Price { get; }
        public string Currency { get; }
    }
}
