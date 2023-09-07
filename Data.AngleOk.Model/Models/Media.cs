using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.AngleOk.Model.Models
{
    public class Media
    {
        public Guid MediaId { get; set; }

        public byte[] Data { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string Extension {  get; set; }
        public Guid RealtyObjectId { get; set; }

        [ForeignKey("RealtyObjectId")]
        public RealtyObject RealtyObject { get; set; }

    }
}
