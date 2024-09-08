using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.AngleOk.Model.Models
{
    /// <summary>
    /// Квартиры
    /// </summary>
    [Table("Flat")]
    [Comment("Квартиры")]
    public class Flat
    {
        /// <summary>
        /// Идентификатор квартиры
        /// </summary>
		[Comment("Идентификатор квартиры")]
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор объекта недвижимости
        /// </summary>
		[Comment("Идентификатор объекта недвижимости")]
        public Guid RealtyObjectId { get; set; }

        /// <summary>
        /// Общая площадь
        /// </summary>
		[Comment("Общая площадь")]
        public decimal TotalArea {  get; set; }

        /// <summary>
        /// Жилая площадь
        /// </summary>
		[Comment("Жилая площадь")]
        public decimal LiveArea {  get; set; }

        /// <summary>
        /// Количество комнат
        /// </summary>
		[Comment("Количество комнат")]
        public int RoomCount {  get; set; }

        /// <summary>
        /// Высота потолков
        /// </summary>
		[Comment("Высота потолков")]
        public decimal CeilingHeight {  get; set; }

        /// <summary>
        /// Этаж
        /// </summary>
		[Comment("Этаж")]
        public int Floor {  get; set; }
        
        /// <summary>
        /// Год постройки
        /// </summary>
		[Comment("Год постройки")]
        public int YearOfBuild { get; set;}
        
        /// <summary>
        /// Материал стен
        /// </summary>
		[Comment("Материал стен")]
        public string MaterialName { get; set; } = string.Empty;
        
        public virtual RealtyObject RealtyObject { get; set; } = null!;
    }
}
