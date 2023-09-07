using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.AngleOk.Model.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Table("Flat")]
    public class Flat
    {
        /// <summary>
        /// Идентификатор квартиры
        /// </summary>
        public Guid FlatId { get; set; }

        /// <summary>
        /// Идентификатор объекта недвижимости
        /// </summary>
        public Guid RealtyObjectId { get; set; }

        /// <summary>
        /// Общая площадь
        /// </summary>
        public decimal TotalArea {  get; set; }

        /// <summary>
        /// Жилая площадь
        /// </summary>
        public decimal LiveArea {  get; set; }

        /// <summary>
        /// Количество комнат
        /// </summary>
        public int RoomCount {  get; set; }

        /// <summary>
        /// Высота потолков
        /// </summary>
        public decimal CeilingHeight {  get; set; }

        /// <summary>
        /// Этаж
        /// </summary>
        public int Floor {  get; set; }
        
        /// <summary>
        /// Год постройки
        /// </summary>
        public int YearOfBuild { get; set;}
        
        /// <summary>
        /// Материал стен
        /// </summary>
        public string MaterialName { get; set; } = string.Empty;
        
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; } = string.Empty;

        [ForeignKey("RealtyObjectId")]
        public RealtyObject RealtyObject { get; set; } = null!;
    }
}
