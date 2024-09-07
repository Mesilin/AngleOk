using AngleOk.Web.Repositories.Abstract;
using Data.AngleOk.Model.Models;

namespace AngleOk.Web.Repositories.EntityFramework
{
    public class EfRealtyObjectRepository(AngleOkContext context) : IRealtyObjectsRepository
    {
        public IQueryable<RealtyObject> GetAll() { return context.RealtyObjects; }

        public RealtyObject? GetRealtyObjectByCadastralNumber(string cadastralNumber)
        {
            return context.RealtyObjects.FirstOrDefault(x => x.CadastralNumber == cadastralNumber);
        }

        public RealtyObject? GetRealtyObjectById(Guid id)
        {
            return context.RealtyObjects.FirstOrDefault(x => x.Id == id);
        }
        public void SaveRealtyObject(RealtyObject realtyObject)
        {
            if (realtyObject.Id == default)
            {
                realtyObject.Id = Guid.NewGuid();
                context.Entry(realtyObject).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            else
                context.Entry(realtyObject).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteRealtyObject(Guid id)
        {
            var realtyObject = GetRealtyObjectById(id);
            if (realtyObject != null)
            {
                context.RealtyObjects.Remove(realtyObject);
            }
        }
    }
}
