using System.ComponentModel.DataAnnotations;

namespace StockManagement.App.ViewModels
{
    public class SupplierViewModel
    {
        //public int SupplierId { get; set; }

        [Required(ErrorMessage ="Shkruaj emrin")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Zgjedh nje shtet")]
        public int CountryId { get; set; }
    }
}
