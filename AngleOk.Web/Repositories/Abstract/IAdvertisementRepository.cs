using Data.AngleOk.Model.Models;

namespace AngleOk.Web.Repositories.Abstract
{
    public interface IAdvertisementRepository
    {
        IQueryable<Advertisement> GetAll();
        Advertisement? GetAdvertisementById(Guid advertisementId);
        void SaveAdvertisement(Advertisement advertisement);
        void DeleteAdvertisement(Guid AdvertisementId);
    }
}
