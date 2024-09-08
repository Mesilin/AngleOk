using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.AngleOk.Model.Models
{
    /// <summary>
    /// Типы сделок (объявлений). аренда, продажа, покупка
    /// </summary>
    [Table("DealType")]
    [Comment("Типы сделок (объявлений). аренда, продажа, покупка")]
    public class DealType
    {
	    [Comment("Идентификатор")]
        public Guid Id { get; set; }

        [DisplayName("Тип сделки")]
	    [Comment("Тип сделки")]
        public string DealTypeName { get; set; } = null!;
    }
}