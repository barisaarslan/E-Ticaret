using System;
using System.ComponentModel.DataAnnotations;

namespace E_Ticaret.Models
{
    public class ProductViewModel
    {
        [Required]
        public string ProductCode { get; set; } = string.Empty; // Varsayılan değer atanıyor

        [Required]
        public string ProductName { get; set; } = string.Empty; // Varsayılan değer atanıyor

        public string Description { get; set; } = string.Empty; // Varsayılan değer atanıyor

        [Range(0, double.MaxValue, ErrorMessage = "Fiyat negatif olamaz.")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Stok miktarı negatif olamaz.")]
        public int StockQuantity { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Sales Start Date")]
        public DateTime SalesStartDate { get; set; }
    }
}
