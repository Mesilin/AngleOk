using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.AngleOk.Model.Enums
{
    /// <summary>
    /// Виды разрешенного использования земли
    /// </summary>
    [Table("SteadUseKind")]
    public class SteadUseKind
    {

        public Guid Id { get; set; }

        [DisplayName("Виды разрешенного использования земли")]
        public string SteadUseKindName { get; set; }

        //[Display(Name = "ИЖС (индивидуальное жилищное строительство)")]
        //PersonalHomeBuilding=0,
        //[Display(Name = "ЛПХ (личное подсобное хозяйство)")]
        //PrivateFarming=1,
        //[Display(Name = "Ведение садоводства или огородничества")]
        //Gardening = 2
    }
}
