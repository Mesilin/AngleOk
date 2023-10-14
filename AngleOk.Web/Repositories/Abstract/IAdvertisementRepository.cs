using Data.AngleOk.Model.Models;

namespace AngleOk.Web.Repositories.Abstract
{
    public interface IAdvertisementRepository
    {
        IQueryable<Advertisement> GetAll();
        Advertisement? GetAdvertisementById(Guid PersonId);
        void SaveAdvertisement(Advertisement person);
        void DeleteAdvertisement(Guid PersonId);
    }
}
