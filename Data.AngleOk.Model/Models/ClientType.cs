using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.AngleOk.Model.Models
{
    /// <summary>
    /// Типы клиентов
    /// </summary>
    [Table("ClientType")]
    public class ClientType
    {
        public Guid Id { get; set; }

        [DisplayName("Тип клиента")]
        public string ClientTypeName { get; set; } = null!;
    }
}