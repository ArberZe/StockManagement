using System.ComponentModel.DataAnnotations;

namespace StockManagement.App.ViewModels
{
    public class CompanyViewModel
    {
        [Required(ErrorMessage ="Shkruani emrin e shtetit")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Zgjedhni një shtet")]
        public int CountryId { get; set; }
    }
}