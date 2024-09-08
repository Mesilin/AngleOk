using System.ComponentModel.DataAnnotations;

namespace AngleOk.Web.Models
{
    public class AccountViewModel
    {
        [Required]
        [Display(Name = "Имя")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Отчество")]
        public string? Patronymic { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; } = null!;

        [Required]
        [Display(Name = "Должность")]
        public string Position { get; set; } = null!;

        [Required]
        [Display(Name = "Личный номер телефона")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [Display(Name = "Рабочий номер телефона")]
        public string PublicPhone { get; set; } = null!;

        [Display(Name = "Адрес электронной почты")]
        public string? Email { get; set; }

        [Required]
        [Display(Name = "Логин")]
        public string UserName { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; } = null!;

        [Required]
        [Display(Name = "Сотрудник действующий?")]
        public bool IsActive { get; set; } = true;
    }
}