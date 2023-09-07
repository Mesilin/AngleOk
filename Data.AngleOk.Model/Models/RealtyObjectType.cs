using System;

namespace Data.AngleOk.Model.Models
{
    /// <summary>
    /// Типы объектов невижимости
    /// </summary>
    public class RealtyObjectType
    {
        public Guid RealtyObjectTypeId { get; set; }
        public required string Name { get; set;}
    }
}
