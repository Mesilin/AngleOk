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
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Идентификатор ФЛ
        /// </summary>
        public Guid PersonId { get; set; }

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

        [ForeignKey("PersonId")]
        public Person Person { get; set; }=null!;
    }
}
