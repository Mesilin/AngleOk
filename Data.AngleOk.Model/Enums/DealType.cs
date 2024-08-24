using System.ComponentModel.DataAnnotations;

namespace Data.AngleOk.Model.Enums
{
    /// <summary>
    /// Типы сделок (объявлений). аренда, продажа, покупка
    /// </summary>
    public enum DealType
    {
        [Display(Name = "Покупка")]
        Покупка = 0,
        
        [Display(Name = "Продажа")]
        Продажа = 1,
        
        [Display(Name = "Аренда")]
        Аренда = 2
    }
}
