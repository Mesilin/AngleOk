using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.AngleOk.Model.Models
{
    [Table("Company")]
    public class Company
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set;}
        public Guid ContactPerson { get; set; }
    }
}
