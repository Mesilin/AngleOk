using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.AngleOk.Model.Models
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public Guid PersonId { get; set; }
        public string PublicPhone {  get; set; }
        public string Position { get; set; }
        public bool IsActive {  get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }
    }
}
