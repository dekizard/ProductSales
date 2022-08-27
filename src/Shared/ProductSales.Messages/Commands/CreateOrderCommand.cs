namespace ProductSales.Messages.Commands
{
    public interface CreateOrderCommand
    {
        public OrderItem[] Orders { get; }
        public string Address { get; }
        public string Email { get; }
    }
}
