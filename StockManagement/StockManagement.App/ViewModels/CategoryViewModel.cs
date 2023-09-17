using System.ComponentModel.DataAnnotations;

namespace StockManagement.App.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }


        [Required(ErrorMessage = "Shkruani emrin e kategorisë")]
        public string Name { get; set; } = string.Empty;
    }
}
