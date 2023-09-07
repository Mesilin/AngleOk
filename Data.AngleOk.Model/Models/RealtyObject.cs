using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        public Guid RealtyObjectId {get; set;}

        /// <summary>
        /// Идентификатор типа
        /// </summary>
        public Guid RealtyObjectTypeId {get; set;}

        /// <summary>
        /// Кадастровый номер
        /// </summary>
        public string? CadastralNumber { get; set;}

        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; } = null!;

        /// <summary>
        /// Широта
        /// </summary>
        public decimal? Latitude { get; set; }

        /// <summary>
        /// Долгота
        /// </summary>
        public decimal? Longitude { get; set; }

        public ICollection<Media> MediaMaterials { get; set; }=null!;

        [ForeignKey("RealtyObjectTypeId")]
        public RealtyObjectType RealtyObjectType { get; set;} = null!;
    }
}
