using System.ComponentModel.DataAnnotations;

namespace AngleOk.Web.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Электронная почта")]
        public string Email { get; set; }

        [Required]
        [UIHint("password")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}
