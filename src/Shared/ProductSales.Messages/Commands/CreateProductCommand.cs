namespace ProductSales.Messages.Commands
{
    public interface CreateProductCommand
    {
        public string Name { get; }
        public string Description { get; }
        public decimal? Price { get; }
    }
}
