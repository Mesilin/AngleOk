using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.AngleOk.Model.Models
{
    /// <summary>
    /// Типы клиентов
    /// </summary>
    [Table("ClientType")]
    [Comment("Типы клиентов")]
	public class ClientType
    {
        public Guid Id { get; set; }

        [DisplayName("Тип клиента")]
		[Comment("Тип клиента")]
        public string ClientTypeName { get; set; } = null!;
    }
}