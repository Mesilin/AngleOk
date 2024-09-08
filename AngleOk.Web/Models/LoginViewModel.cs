using System.ComponentModel.DataAnnotations;

namespace AngleOk.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Логин")]
        public string UserName { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; } = null!;

        [Display(Name ="Запомнить?")]
        public bool RememberMe { get; set; }
    }
}