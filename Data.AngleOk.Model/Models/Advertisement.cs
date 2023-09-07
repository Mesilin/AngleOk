using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.AngleOk.Model.Models
{
    /// <summary>
    /// Объявления
    /// </summary>
    [DisplayName("Объявления")]
    public class Advertisement
    {
        /// <summary>
        /// Идентификатор объявления
        /// </summary>
        public Guid AdvertisementId {  get; set; }

        /// <summary>
        /// Идентификатор договора
        /// </summary>
        public Guid ContractId { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public int Price {  get; set; }

        /// <summary>
        /// Идентификатор объекта недвижимости
        /// </summary>
        public Guid RealtyObjectId { get; set; }

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

        [ForeignKey("ContractId")]
        public Contract Contract { get; set; }

        [ForeignKey("RealtyObjectId")]
        public RealtyObject RealtyObject { get; set; }

        [ForeignKey("ManagerId")]
        public Person Manager { get; set; }


    }
}
