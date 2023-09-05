using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.AngleOk.Model.Models
{
    /// <summary>
    /// Люди
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid PersonId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        public string Description { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; }= string.Empty;
    }
}
