using System;
using System.ComponentModel;
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
        [DisplayName("Имя")]
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        [DisplayName("Отчество")]
        public string? Patronymic { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [DisplayName("Фамилия")]
        public string LastName { get; set; }

        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        [DisplayName("Почта")]
        public string? Email { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        [DisplayName("телефон личный")]
        public string PhoneNumber { get; set; }
        
        /// <summary>
        /// Публичный номер телефона
        /// </summary>
        [DisplayName("Телефон рабочий")]
        public string? PublicPhone {  get; set; }

        /// <summary>
        /// Должность
        /// </summary>
        [DisplayName("Должность")]
        public string Position { get; set; } = null!;

        /// <summary>
        /// Признак действующего сотрудника
        /// </summary>
        [DisplayName("Действующий сотрудник")]
        [DefaultValue(true)]
        public bool IsActive { get; set; } = true;
    }
}
