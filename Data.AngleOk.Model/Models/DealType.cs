using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.AngleOk.Model.Models
{
    /// <summary>
    /// Типы искомых сделок (объявлений). аренда, продажа, покупка
    /// </summary>
    [Table("DealType")]
    public class DealType
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid DealTypeId { get; set; }

        /// <summary>
        /// Наименование типа
        /// </summary>
        public string Name { get; set; } = null!;
    }
}
