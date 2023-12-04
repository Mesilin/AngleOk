using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data.AngleOk.Model.Models
{
    /// <summary>
    /// Владельцы объектов недвижимости
    /// </summary>
    [DisplayName("Владельцы объектов недвижимости")]
    [Table("RealtyObjectOwner")]
    public class RealtyObjectOwner
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Владелец ФЛ
        /// </summary>
        public Guid? ClientId { get; set; }

        /// <summary>
        /// Владелец ЮЛ
        /// </summary>
        public Guid? CompanyId { get; set; }


        public Guid RealtyObjectId { get; set; }

        /// <summary>
        /// Доля в собственности
        /// </summary>
        [Range(0,100)]
        [DefaultValue(100)]
        public decimal PartPercent { get; set; }
    }
}
