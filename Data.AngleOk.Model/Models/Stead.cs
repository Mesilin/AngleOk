using Data.AngleOk.Model.Enums;
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
        public Guid Id { get; set; }
        
        /// <summary>
        /// Идентификатор объекта недвижимости
        /// </summary>
        public Guid RealtyObjectId { get; set; }
        
        /// <summary>
        /// Площадь
        /// </summary>
        public decimal Area { get; set; }
        
        public virtual RealtyObject RealtyObject { get; set; } = null!;

        public SteadUseKind SteadUseKind { get; set; }

     }
}
