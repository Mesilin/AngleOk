using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.AngleOk.Model.Enums
{
    /// <summary>
    /// Типы сделок (объявлений). аренда, продажа, покупка
    /// </summary>
    [Table("DealType")]
    public class DealType
    {
        public Guid Id { get; set; }

        [DisplayName("Тип сделки")]
        public string DealTypeName { get; set; } = null!;
    }
}