using Data.AngleOk.Model.Enums;
using Data.AngleOk.Model.Models;
using System.ComponentModel.DataAnnotations;

namespace AngleOk.Web.Models
{
    public class AdvertisementCreateViewModel
    {
        [Display(Name = "Цена")]
        public int TargetPrice { get; set; }
        [Display(Name = "Минимальная цена")]
        public int MinPrice { get; set; }
        [Display(Name = "Максимальная цена")]
        public int MaxPrice { get; set; }
        
        [Display(Name = "Объявление активно")]
        public bool IsActive { get; set; } = true;
        [Display(Name = "Описание")]
        public string Description { get; set; } = string.Empty;

        [MaxLength(50)]
        [Display(Name = "Краткое описание")]
        public string ShortDescription { get; set; } = string.Empty;

        [Display(Name = "Объект")]
        public List<RealtyObject>? RealtyObjects { get; set; }

        [Display(Name = "Клиент")]
        public List<Client>? Clients { get; set; }

        [Display(Name = "Менеджерh")]
        public List<Employee>? Managers { get; set; }

        [Display(Name = "Тип объявления")]
        public List<DealType>? DealTypes { get; set; }

        public Guid? SelectedRealtyObjectId { get; set; }
        public Guid SelectedClientId{ get; set; }
        public Guid SelectedManagerId{ get; set; }
        public Guid SelectedDealTypeId { get; set; }
    }
}