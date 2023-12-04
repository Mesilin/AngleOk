using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.AngleOk.Model.Enums;

namespace Data.AngleOk.Model.Models
{
    /// <summary>
    /// Объявления
    /// </summary>
    [DisplayName("Объявления")]
    [Table("Advertisement")]
    public class Advertisement
    {
        /// <summary>
        /// Идентификатор объявления
        /// </summary>
        public Guid Id {  get; set; }

        /// <summary>
        /// Идентификатор клиента
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        /// Тип(аренда, продажа, покупка)
        /// </summary>
        public DealType DealType { get; set; }

        /// <summary>
        /// Идентификатор объекта недвижимости
        /// </summary>
        public Guid? RealtyObjectId { get; set; }

        /// <summary>
        /// Целевая цена
        /// </summary>
        public int TargetPrice { get; set; }

        /// <summary>
        /// Минимальная цена
        /// </summary>
        public int MinPrice { get; set; }

        /// <summary>
        /// Максимальная цена
        /// </summary>
        public int MaxPrice { get; set; }

        /// <summary>
        /// Идентификатор контактного лица от агентства
        /// </summary>
        public Guid ManagerId { get; set; }

        /// <summary>
        /// Статус объявления
        /// </summary>
        public bool IsActive {  get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Краткое описание
        /// </summary>
        [MaxLength(50)]
        public string ShortDescription { get; set; } = string.Empty;

        public virtual RealtyObject RealtyObject { get; set; } = null!;

        [ForeignKey("ManagerId")]
        public virtual required Employee Manager { get; set; }

        [ForeignKey("Id")]
        public virtual required Client Client{ get; set; }

        public virtual List<Media>? MediaCollection { get; set; }
    }
}
