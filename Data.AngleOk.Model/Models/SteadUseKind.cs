using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.AngleOk.Model.Models
{
    /// <summary>
    /// Виды разрешенного использования земли
    /// </summary>
    [Table("SteadUseKind")]
    [Comment("Виды разрешенного использования земли")]
    public class SteadUseKind
    {

		[Comment("Идентификатор")]
        public Guid Id { get; set; }

		[Comment("Вид разрешенного использования земли")]
        [DisplayName("Виды разрешенного использования земли")]
        public string SteadUseKindName { get; set; } = null!;
    }
}