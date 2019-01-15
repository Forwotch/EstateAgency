using System.ComponentModel.DataAnnotations;

namespace EstateAgency.API.Models.Authentication
{
    public class UserRegisterModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public string PasswordConfirm { get; set; }
    }
}