using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.AngleOk.Model.Models
{
    /// <summary>
    /// Таблица Клиенты физлица
    /// </summary>
    [Table("Client")]
    public class Client
    {
        
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [DisplayName("Имя")]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// Отчество
        /// </summary>
        [DisplayName("Отчество")]
        public string? Patronymic { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [DisplayName("Фамилия")]
        public string LastName { get; set; } = null!;

        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        [DisplayName("Номер телефона")]
        public string PhoneNumber { get; set; } = null!;

        [NotMapped]
        public string Fullname => $"{FirstName} {LastName}";
    }
}
