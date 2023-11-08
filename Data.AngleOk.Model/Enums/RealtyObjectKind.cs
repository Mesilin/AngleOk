using System.ComponentModel.DataAnnotations;

namespace Data.AngleOk.Model.Enums
{
    /// <summary>
    /// Виды объектов невижимости
    /// </summary>
    public enum RealtyObjectKind
    {
        [Display(Name = "Квартира")] Flat = 0,
        [Display(Name = "Дом")] Cottage = 1,
        [Display(Name = "Дача")] SummerCottage = 2,
        [Display(Name = "Земельный участок")] Stead = 3,
        [Display(Name = "Гараж")] Garage = 4
    }
}
