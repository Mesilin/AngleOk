using System;

namespace Data.AngleOk.Model.Models
{
    /// <summary>
    /// Таблица Люди
    /// </summary>
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
        public string Patronymic { get; set; } = string.Empty;

        /// <summary>
        /// Фамилия
        /// </summary>
        public required string LastName { get; set; }

        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get; set; }= string.Empty;
    }
}
