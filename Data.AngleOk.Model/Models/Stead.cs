using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.AngleOk.Model.Models
{
    /// <summary>
    /// Земельные участки
    /// </summary>
    [Table("Stead")]
    [Comment("Земельные участки")]
    public class Stead
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
		[Comment("Идентификатор")]
		public Guid Id { get; set; }
        
        /// <summary>
        /// Идентификатор объекта недвижимости
        /// </summary>
		[Comment("Идентификатор объекта недвижимости")]
        public Guid RealtyObjectId { get; set; }
        
        /// <summary>
        /// Площадь, метров квадратных
        /// </summary>
		[Comment("Площадь")]
        public decimal Area { get; set; }
        

		[Comment("Идентификатор вида разрешенного использования")]
        public Guid SteadUseKindId { get; set; }
        
        [ForeignKey("SteadUseKindId")]
		[Comment("вид разрешенного использования")]
		public virtual SteadUseKind? SteadUseKind { get; set; }
        public virtual RealtyObject RealtyObject { get; set; } = null!;

    }
}
