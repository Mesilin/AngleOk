using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.AngleOk.Model.Models
{
    /// <summary>
    /// Объекты недвижимости
    /// </summary>
    [Table("RealtyObject")]
    [Comment("Объекты недвижимости")]
    public class RealtyObject
    {
		/// <summary>
		/// Идентификатор
		/// </summary>
		[Comment("Идентификатор")] 
		public Guid Id {get; set;}

        [Display(Name = "Кадастровый номер")]
		[Comment("Кадастровый номер")] 
        public string CadastralNumber { get; set;} = null!;

        [Display(Name = "Адрес")]
		[Comment("Адрес")] 
        public string Address { get; set; } = null!;

        [Display(Name = "Широта")]
		[Comment("Широта")] 
        public decimal? Latitude { get; set; }

        [Display(Name = "Долгота")]
		[Comment("Долгота")] 
        public decimal? Longitude { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [Display(Name = "Описание")]
		[Comment("Описание")] 
        public string? Description { get; set; }

        /// <summary>
        /// Тип
        /// </summary>
        public Guid RealtyObjectKindId { get; set; }
        [ForeignKey("RealtyObjectKindId")]
		[Comment("тип")] 
        public virtual RealtyObjectKind? RealtyObjectKind { get; set; } = null!;

        /// <summary>
        /// Список фотографий и пр медиаматериалов
        /// </summary>
        public virtual List<Media>? MediaMaterials { get; set; }
    }
}
