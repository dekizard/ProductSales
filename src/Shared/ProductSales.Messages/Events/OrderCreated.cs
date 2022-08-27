namespace ProductSales.Messages.Events
{
    public interface OrderCreated
    {
        public OrderItem[] Orders { get; }
        public decimal? TotalPrice { get; }
        public string Email { get; }
    }
}
