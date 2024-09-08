using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.AngleOk.Model.Models
{
    /// <summary>
    /// Объявления
    /// </summary>
    [DisplayName("Объявления")]
    [Table("Advertisement")]
    [Comment("Объявления")]
    public class Advertisement
    {
        /// <summary>
        /// Идентификатор объявления
        /// </summary>
        [Comment("Идентификатор объявления")]
        public Guid Id {  get; set; }

        /// <summary>
        /// Идентификатор клиента
        /// </summary>
        [Display(Name = "Клиент")]
        [Comment("Идентификатор клиента")]
		public Guid ClientId { get; set; }

        /// <summary>
        /// Тип(аренда, продажа, покупка)
        /// </summary>
        [Display(Name = "Тип сделки")]
        [Comment("Тип(аренда, продажа, покупка)")]
        public Guid DealTypeId { get; set; }

        /// <summary>
        /// Идентификатор объекта недвижимости
        /// </summary>
        [Display(Name = "Объект")]
        [Comment("Идентификатор объекта недвижимости")]
        public Guid? RealtyObjectId { get; set; }

        /// <summary>
        /// Целевая цена
        /// </summary>
        [Display(Name = "Целевая цена")]
        [Comment("Целевая цена")]
        public int TargetPrice { get; set; }

        /// <summary>
        /// Минимальная цена
        /// </summary>
        [Display(Name = "Минимальная цена")]
        [Comment("Минимальная цена")]
        public int MinPrice { get; set; }

        /// <summary>
        /// Максимальная цена
        /// </summary>
        [Display(Name = "Максимальная цена")]
        [Comment("Максимальная цена")]
        public int MaxPrice { get; set; }

        /// <summary>
        /// Идентификатор контактного лица от агентства
        /// </summary>
        [Display(Name = "Менеджер")]
        [Comment("Идентификатор контактного лица от агентства")]
        public Guid ManagerId { get; set; }

        /// <summary>
        /// Статус объявления
        /// </summary>
        [DefaultValue(true)]
        [Comment("Признак активности")]
        [Display(Name = "Активно?")]
        public bool IsActive {  get; set; } = true;

        /// <summary>
        /// Описание
        /// </summary>
        [Display(Name = "Описание")]
        [Comment("Описание")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Краткое описание
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "Краткое описание")]
        [Comment("Краткое описание")]
        public string ShortDescription { get; set; } = string.Empty;

        public virtual RealtyObject? RealtyObject { get; set; } = null!;

        [ForeignKey("ManagerId")]
        public virtual Employee? Manager { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client? Client{ get; set; }

        [ForeignKey("DealTypeId")]
        public virtual DealType? DealType { get; set; }
    }
}
