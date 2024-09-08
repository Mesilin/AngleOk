using System;
using System.ComponentModel;
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
		[Comment("Имя")]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// Отчество
        /// </summary>
        [DisplayName("Отчество")]
		[Comment("Отчество")]
        public string? Patronymic { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [DisplayName("Фамилия")]
		[Comment("Фамилия")]
        public string LastName { get; set; } = null!;

        /// <summary>
        /// Адрес электронной почты
        /// </summary>
		[Comment("Адрес электронной почты")]
        public string? Email { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        [DisplayName("Номер телефона")]
		[Comment("Номер телефона")]
        public string PhoneNumber { get; set; } = null!;

        [NotMapped]
        public string Fullname => $"{FirstName} {LastName}";
    }
}
