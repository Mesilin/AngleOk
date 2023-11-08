using System.ComponentModel.DataAnnotations;

namespace Data.AngleOk.Model.Enums
{
    /// <summary>
    /// Виды разрешенного использования земли
    /// </summary>
    public enum SteadUseKind
    {
        [Display(Name = "ИЖС (индивидуальное жилищное строительство)")]
        PersonalHomeBuilding=0,
        [Display(Name = "ЛПХ (личное подсобное хозяйство)")]
        PrivateFarming=1,
        [Display(Name = "Ведение садоводства или огородничества")]
        Gardening = 2
    }
}
