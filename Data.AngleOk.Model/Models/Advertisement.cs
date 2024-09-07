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
        [Display(Name = "Клиент")]
        public Guid ClientId { get; set; }

        /// <summary>
        /// Тип(аренда, продажа, покупка)
        /// </summary>
        [Display(Name = "Тип сделки")]
        public Guid DealTypeId { get; set; }

        /// <summary>
        /// Идентификатор объекта недвижимости
        /// </summary>
        [Display(Name = "Объект")]
        public Guid? RealtyObjectId { get; set; }

        /// <summary>
        /// Целевая цена
        /// </summary>
        [Display(Name = "Целевая цена")]
        public int TargetPrice { get; set; }

        /// <summary>
        /// Минимальная цена
        /// </summary>
        [Display(Name = "Минимальная цена")]
        public int MinPrice { get; set; }

        /// <summary>
        /// Максимальная цена
        /// </summary>
        [Display(Name = "Максимальная цена")]
        public int MaxPrice { get; set; }

        /// <summary>
        /// Идентификатор контактного лица от агентства
        /// </summary>
        [Display(Name = "Менеджер")]
        public Guid ManagerId { get; set; }

        /// <summary>
        /// Статус объявления
        /// </summary>
        [DefaultValue(true)]
        [Display(Name = "Активно?")]
        public bool IsActive {  get; set; } = true;

        /// <summary>
        /// Описание
        /// </summary>
        [Display(Name = "Описание")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Краткое описание
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "Краткое описание")]
        public string ShortDescription { get; set; } = string.Empty;

        public virtual RealtyObject? RealtyObject { get; set; } = null!;

        [ForeignKey("ManagerId")]
        public virtual Employee? Manager { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client? Client{ get; set; }

        [ForeignKey("DealTypeId")]
        public virtual DealType? DealType { get; set; }

        public virtual List<Media>? MediaCollection { get; set; }
    }
}
