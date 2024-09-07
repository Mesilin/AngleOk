using Data.AngleOk.Model.Models;

namespace AngleOk.Web.Repositories.Abstract
{
    public interface IRealtyObjectsRepository
    {
        IQueryable<RealtyObject> GetAll();
        RealtyObject? GetRealtyObjectById(Guid realtyObjectId);
        void SaveRealtyObject(RealtyObject realtyObject);
        void DeleteRealtyObject(Guid id);
    }
}
