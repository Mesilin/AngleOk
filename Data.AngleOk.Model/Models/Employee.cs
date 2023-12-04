using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.AngleOk.Model.Models
{
    /// <summary>
    /// Сотрудники
    /// </summary>
    [Table("Employee")]
    public class Employee
    {
        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string? Patronymic { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get; set; }
        
        /// <summary>
        /// Публичный номер телефона
        /// </summary>
        public string? PublicPhone {  get; set; }

        /// <summary>
        /// Должность
        /// </summary>
        public string Position { get; set; } = null!;

        /// <summary>
        /// Признак действующего сотрудника
        /// </summary>
        public bool IsActive {  get; set; }
    }
}
