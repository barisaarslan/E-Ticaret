using System.ComponentModel.DataAnnotations;

namespace E_Ticaret.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty; // Varsayılan değer atanıyor

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty; // Varsayılan değer atanıyor

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
