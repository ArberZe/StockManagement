namespace StockManagement.Application.Features.Countries.Commands.CreateCountry
{
    public class CreateCountryDto
    {
        public int CountryId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}