using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.AngleOk.Model.Models
{
    /// <summary>
    /// Виды объектов невижимости
    /// </summary>
    
    [Table("RealtyObjectKind")]
    [Comment("Виды объектов невижимости")]
    public class RealtyObjectKind
    {
		[Comment("Идентификатор")]
		public Guid Id { get; set; }

        [DisplayName("Тип объекта невижимости")]
		[Comment("Тип объекта невижимости")]
		public string RealtyObjectKindName { get; set; } = null!;
    }
}
