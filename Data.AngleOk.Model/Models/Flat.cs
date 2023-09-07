using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.AngleOk.Model.Models
{
    public class Flat
    {
        public Guid FlatId { get; set; }
        public Guid RealtyObjectId { get; set; }
        public decimal TotalArea {  get; set; }
        public decimal LiveArea {  get; set; }
        public int RoomCount {  get; set; }

        /// <summary>
        /// Высота потолков
        /// </summary>
        public decimal CeilingHeight {  get; set; }

        public int Floor {  get; set; }
        public int YearOfBuild { get; set;}
        public string MaterialName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [ForeignKey("RealtyObjectId")]
        public RealtyObject RealtyObject { get; set; }
    }
}
