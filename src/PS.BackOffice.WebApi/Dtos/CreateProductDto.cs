namespace PS.BackOffice.WebApi.Dtos
{
    public record CreateProductDto(string Name, string Description, decimal? Price, string Currency);
}
