using Data.AngleOk.Model.Enums;
using Data.AngleOk.Model.Models;
using System.ComponentModel.DataAnnotations;

namespace AngleOk.Web.Models
{
    public class AdvertisementCreateViewModel
    {
        // Параметры объявления
        [Display(Name = "Клиент")]
        public Guid ClientId { get; set; }
        [Display(Name = "Тип объявления")]
        public DealType DealType { get; set; }

        [Display(Name = "Цена")]
        public int TargetPrice { get; set; }
        [Display(Name = "Минимальная цена")]
        public int MinPrice { get; set; }
        [Display(Name = "Максимальная цена")]
        public int MaxPrice { get; set; }
        [Display(Name = "Контакт")]
        public Guid ManagerId { get; set; }

        [Display(Name = "Объявление активно")]
        public bool IsActive { get; set; } = true;
        [Display(Name = "Описание")]
        public string Description { get; set; } = string.Empty;

        [MaxLength(50)]
        [Display(Name = "Краткое описание")]
        public string ShortDescription { get; set; } = string.Empty;

        // Связанные объекты недвижимости
        [Display(Name = "Объект")]
        public List<RealtyObject> RealtyObjects { get; set; } = new();

        // Параметры для создания нового объекта недвижимости
        public bool NewRealtyObject { get; set; }
        [Display(Name = "Тип")]
        public RealtyObjectKind RealtyObjectKind { get; set; }
        [Display(Name = "Кадастровый номер")]
        public string CadastralNumber { get; set; } = null!;
        [Display(Name = "Адрес")]
        public string Address { get; set; } = null!;
        [Display(Name = "Широта")]
        public decimal? Latitude { get; set; }
        [Display(Name = "Долгота")]
        public decimal? Longitude { get; set; }
        public Guid? SelectedRealtyObjectId { get; set; }
    }
}
