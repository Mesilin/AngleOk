using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.AngleOk.Model.Models
{
    public class RealtyObject
    {
        public RealtyObject() { }
        public Guid RealtyObjectId {get; set;}
        public Guid RealtyObjectTypeId {get; set;}
        public string CadastralNumber { get; set;}
        public string Address { get; set;}

        public ICollection<Media> MediaMaterials { get; set;}

        [ForeignKey("RealtyObjectTypeId")]
        public RealtyObjectType RealtyObjectType { get; set;}
    }
}
