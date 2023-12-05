using System.ComponentModel.DataAnnotations;

namespace AngleOk.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Логин")]
        public string UserName { get; set; }

        [Required]
        //[UIHint("password")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name ="Запомнить?")]
        public bool RememberMe { get; set; }
    }
}
