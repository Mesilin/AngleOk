using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.AngleOk.Model.Models
{
    /// <summary>
    /// Сотрудники
    /// </summary>
    [Table("Employee")]
    [Comment("Сотрудники агентства")]
	public class Employee
    {
        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
		[Comment("Идентификатор сотрудника")]
        public Guid Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [DisplayName("Имя")]
        [Required(ErrorMessage = "Поле Имя обязательно для заполнения")]
		[Comment("Имя")]
        [RegularExpression(@"^[а-яА-Я''-'\s]{1,40}$", ErrorMessage = "Некорректные символы в поле Имя. Длина должна быть от 1 до 40 символов")]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// Отчество
        /// </summary>
        [DisplayName("Отчество")]
		[Comment("Отчество")]
        [RegularExpression(@"^[а-яА-Я''-'\s]{0,40}$", ErrorMessage = "Некорректные символы в поле Отчество. Длина должна быть от 0 до 40 символов")]
        public string? Patronymic { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [DisplayName("Фамилия")]
		[Comment("Фамилия")]
        [Required(ErrorMessage = "Поле Фамилия обязательно для заполнения")]
        [RegularExpression(@"^[а-яА-Я''-'\s]{1,40}$", ErrorMessage = "Некорректные символы в поле Фамилия. Длина должна быть от 1 до 40 символов")]
        public string LastName { get; set; } = null!;

        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        [DisplayName("Почта")]
		[Comment("Адрес электронной почты")]
		[EmailAddress(ErrorMessage = "Некорректный адрес электронной почты")]
        public string? Email { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        [DisplayName("телефон личный")]
		[Comment("телефон личн")]
        [Phone(ErrorMessage = "Некорректный номер телефона")]
        [Required(ErrorMessage = "Не указан телефон")]
        public string PhoneNumber { get; set; } = null!;

        /// <summary>
        /// Публичный номер телефона
        /// </summary>
        [DisplayName("Телефон рабочий")]
		[Comment("Телефон раб")]
        [Phone(ErrorMessage = "Некорректный номер телефона")]
        public string? PublicPhone {  get; set; }

        /// <summary>
        /// Должность
        /// </summary>
        [DisplayName("Должность")]
		[Comment("Должность")]
        public string Position { get; set; } = null!;

        /// <summary>
        /// Признак действующего сотрудника
        /// </summary>
        [DisplayName("Действующий сотрудник")]
        [DefaultValue(true)]
		[Comment("Признак действующего сотрудника")]
        public bool IsActive { get; set; } = true;
    }
}
