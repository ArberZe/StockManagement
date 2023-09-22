using System.ComponentModel.DataAnnotations;

namespace StockManagement.App.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Shkruaj emrin")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Shkruaj përshkrimin")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Shkruaj cmimin")]
        public decimal SellingPrice { get; set; }

        [Required(ErrorMessage = "Zgjedh kategorinë")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Zgjedh kompaninë")]
        public int CompanyId { get; set; }
    }
}
