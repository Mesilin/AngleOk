using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.AngleOk.Model.Models
{
    /// <summary>
    /// Типы объектов невижимости
    /// </summary>
    [Table("RealtyObjectType")]
    public class RealtyObjectType
    {
        public Guid RealtyObjectTypeId { get; set; }
        public required string Name { get; set;}
    }
}
