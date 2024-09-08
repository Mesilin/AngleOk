using System;
using System.ComponentModel;
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
        [DisplayName("Почта")]
		[Comment("Адрес электронной почты")]
        public string? Email { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        [DisplayName("телефон личный")]
		[Comment("телефон личн")]
        public string PhoneNumber { get; set; } = null!;

        /// <summary>
        /// Публичный номер телефона
        /// </summary>
        [DisplayName("Телефон рабочий")]
		[Comment("Телефон раб")]
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
