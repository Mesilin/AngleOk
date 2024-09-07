using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.AngleOk.Model.Enums
{
    /// <summary>
    /// Виды объектов невижимости
    /// </summary>
    
    [Table("RealtyObjectKind")]
    public class RealtyObjectKind
    {
        public Guid Id { get; set; }

        [DisplayName("Тип объекта невижимости")]
        public string RealtyObjectKindName { get; set; } = null!;
    }
}
