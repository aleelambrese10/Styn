using System.ComponentModel.DataAnnotations;

namespace Styn.Application.Models
{
    public class RegisterRequest
    {
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direcion { get; set; }
        public string Dni { get; set; }
        public string? Role { get; set; } = "User";


    }
}
