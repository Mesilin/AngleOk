using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.AngleOk.Model.Models
{
    /// <summary>
    /// Типы земельных участков (виды назначения земель)
    /// </summary>
    [Table("SteadKind")]
    public class SteadKind
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid SteadKindId {  get; set; }

        /// <summary>
        /// Назначение земель
        /// </summary>
        public string Name { get; set; } = null!;
    }
}
