using System.ComponentModel.DataAnnotations;

namespace StockManagement.App.ViewModels
{
    public class CountryViewModel
    {
        public int CountryId { get; set; }

        [Required(ErrorMessage ="Shkruaj emrin")]
        public string Name { get; set; } = string.Empty;
    }
}