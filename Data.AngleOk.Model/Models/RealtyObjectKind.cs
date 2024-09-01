using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.AngleOk.Model.Enums
{
    /// <summary>
    /// Виды объектов невижимости
    /// </summary>
    
    [Table("RealtyObjectKind")]
    public class RealtyObjectKind
    {
        public Guid Id { get; set; }

        [DisplayName("Тип объекта невижимости")]
        public string RealtyObjectKindName { get; set; }

        //[Display(Name = "Квартира")] flat = 0,
        //[Display(Name = "Дом")] Дом = 1,
        //[Display(Name = "Дача")] Дача = 2,
        //[Display(Name = "Земельный участок")] Земля = 3,
        //[Display(Name = "Гараж")] Гараж = 4
    }
}
