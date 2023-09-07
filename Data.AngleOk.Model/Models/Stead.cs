using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.AngleOk.Model.Models
{
    public class Stead
    {
        public Guid SteadId { get; set; }
        public Guid RealtyObjectId { get; set; }
        public decimal Area { get; set; }
        public string Description { get; set; }
        public Guid SteadKindId { get; set; }


        [ForeignKey("RealtyObjectId")]
        public RealtyObject RealtyObject { get; set; }

        [ForeignKey("SteadKindId")]
        public SteadKind SteadKind { get; set; }
     }
}
