using System.ComponentModel.DataAnnotations;

namespace Data.AngleOk.Model.Enums
{
    /// <summary>
    /// Типы сделок (объявлений). аренда, продажа, покупка
    /// </summary>
    public enum DealType
    {
        [Display(Name = "Покупка")]
        Buying = 0,
        
        [Display(Name = "Продажа")]
        Selling = 1,
        
        [Display(Name = "Аренда")]
        Renting=2
    }
}
