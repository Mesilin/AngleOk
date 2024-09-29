using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.AngleOk.Model.Models
{
    /// <summary>
    /// Таблица Клиенты
    /// </summary>
    [Table("Client")]
    [Comment("Таблица Клиенты")]
    public class Client
	{
        
        /// <summary>
        /// Идентификатор
        /// </summary>
		[Comment("Идентификатор")]
        public Guid Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [DisplayName("Имя")]
        [Required(ErrorMessage = "Не указано имя")]
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
        [Required(ErrorMessage = "Не указана Фамилия")]
        [RegularExpression(@"^[а-яА-Я''-'\s]{1,40}$", ErrorMessage = "Некорректные символы в поле Фамилия. Длина должна быть от 1 до 40 символов")]
        public string LastName { get; set; } = null!;

        /// <summary>
        /// Адрес электронной почты
        /// </summary>
		[Comment("Адрес электронной почты")]
		[EmailAddress(ErrorMessage = "Некорректный адрес электронной почты")]
		public string? Email { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        [DisplayName("Номер телефона")]
		[Comment("Номер телефона")]
        [Phone(ErrorMessage = "Некорректный номер телефона")]
        [Required(ErrorMessage = "Не указан телефон")]
        public string PhoneNumber { get; set; } = null!;

        [NotMapped]
        public string Fullname => $"{FirstName} {LastName}";
    }
}
