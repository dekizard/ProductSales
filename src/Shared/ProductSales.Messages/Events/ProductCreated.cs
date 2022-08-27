namespace ProductSales.Messages.Events
{
    public interface ProductCreated
    {
        public string Name { get; }
        public decimal? Price { get; }
        public string Currency { get; }
    }
}
