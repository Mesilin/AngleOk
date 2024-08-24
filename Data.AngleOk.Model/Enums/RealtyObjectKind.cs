using System.ComponentModel.DataAnnotations;

namespace Data.AngleOk.Model.Enums
{
    /// <summary>
    /// Виды объектов невижимости
    /// </summary>
    public enum RealtyObjectKind
    {
        [Display(Name = "Квартира")] Квартира = 0,
        [Display(Name = "Дом")] Дом = 1,
        [Display(Name = "Дача")] Дача = 2,
        [Display(Name = "Земельный участок")] Земля = 3,
        [Display(Name = "Гараж")] Гараж = 4
    }
}
