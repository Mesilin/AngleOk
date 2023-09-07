using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.AngleOk.Model.Models
{
    /// <summary>
    /// Таблица Люди
    /// </summary>
    [Table("Person")]
    public class Person
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid PersonId { get; set; }
        
        /// <summary>
        /// Имя
        /// </summary>
        public required string FirstName { get; set; }
        
        /// <summary>
        /// Отчество
        /// </summary>
        public string? Patronymic { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public required string LastName { get; set; }

        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public required string PhoneNumber { get; set; }
    }
}
