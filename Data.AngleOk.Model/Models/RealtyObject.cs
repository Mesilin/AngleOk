using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.AngleOk.Model.Enums;

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

        [Display(Name = "Тип")]
        public RealtyObjectKind RealtyObjectKind { get; set; }

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
        /// Титульное фото
        /// </summary>
        public Guid? TitleImageId { get; set; }
        [ForeignKey("TitleImageId")]
        public virtual Media? TitleImage { get; set; }

        /// <summary>
        /// Список фотографий и пр медиаматериалов
        /// </summary>
        public virtual List<Media>? MediaMaterials { get; set; }

        ///// <summary>
        ///// Владельцы объектов недвижимости
        ///// </summary>
        //public virtual required List<RealtyObjectOwner> RealtyObjectOwners { get; set; }
    }
}
