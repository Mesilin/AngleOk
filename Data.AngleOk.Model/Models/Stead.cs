using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.AngleOk.Model.Models
{
    /// <summary>
    /// Земельные участки
    /// </summary>
    [Table("Stead")]
    public class Stead
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid SteadId { get; set; }
        
        /// <summary>
        /// Идентификатор объекта недвижимости
        /// </summary>
        public Guid RealtyObjectId { get; set; }
        
        /// <summary>
        /// Площадь
        /// </summary>
        public decimal Area { get; set; }
        
        /// <summary>
        /// Описание
        /// </summary>
        public string? Description { get; set; }
        
        /// <summary>
        /// Идентификатор назначения земель
        /// </summary>
        public Guid SteadKindId { get; set; }

        [ForeignKey("RealtyObjectId")]
        public RealtyObject RealtyObject { get; set; } = null!;

        [ForeignKey("SteadKindId")]
        public SteadKind SteadKind { get; set; } = null!;
     }
}
