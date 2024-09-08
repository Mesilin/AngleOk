using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.AngleOk.Model.Enums;
using Microsoft.EntityFrameworkCore;

namespace Data.AngleOk.Model.Models
{
    /// <summary>
    /// Объекты недвижимости
    /// </summary>
    [Table("RealtyObject")]
    public class RealtyObject
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id {get; set;}

        [Display(Name = "Кадастровый номер")]
        public string CadastralNumber { get; set;} = null!;

        [Display(Name = "Адрес")]
        public string Address { get; set; } = null!;

        [Display(Name = "Широта")]
        public decimal? Latitude { get; set; }

        [Display(Name = "Долгота")]
        public decimal? Longitude { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [Display(Name = "Описание")]
        public string? Description { get; set; }

        /// <summary>
        /// Тип
        /// </summary>
        public Guid RealtyObjectKindId { get; set; }
        [ForeignKey("RealtyObjectKindId")]
        public virtual RealtyObjectKind? RealtyObjectKind { get; set; } = null!;

        /// <summary>
        /// Список фотографий и пр медиаматериалов
        /// </summary>
        public virtual List<Media>? MediaMaterials { get; set; }
    }
}
