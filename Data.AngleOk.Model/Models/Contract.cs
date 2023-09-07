using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.AngleOk.Model.Models
{
    public class Contract
    {
        /// <summary>
        /// Идентификатор договора
        /// </summary>
        public Guid ContractId { get; set; }
        
        /// <summary>
        /// Идентификатор клиента
        /// </summary>
        public Guid ClientId{ get; set; }

        /// <summary>
        /// Идентификатор типа сделки
        /// </summary>
        public Guid DealTypeId { get; set; }

        /// <summary>
        /// Идентификатор объекта недвижимости
        /// </summary>
        public Guid? RealtyObjectId { get; set; }

        /// <summary>
        /// Минимальная цена
        /// </summary>
        public int MinPrice {  get; set; }

        /// <summary>
        /// Максимальная цена
        /// </summary>
        public int MaxPrice { get; set; }

        [ForeignKey("ClientId")]
        public Person Client {  get; set; }

        [ForeignKey("DealTypeId")]
        public virtual DealType DealType { get; set; }

        [ForeignKey("RealtyObjectId")]
        public virtual RealtyObject RealtyObject { get; set; }
    }
}
