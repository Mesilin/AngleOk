using AngleOk.Web.Repositories.Abstract;
using Data.AngleOk.Model.Models;

namespace AngleOk.Web.Repositories.EntityFramework
{
    public class EFAdvertisementRepository : IAdvertisementRepository
    {
        private readonly AngleOkContext context;
        public EFAdvertisementRepository(AngleOkContext context) { this.context = context; }
        public IQueryable<Advertisement> GetAll() 
        { 
            return context.Advertisements; 
        }
        public Advertisement? GetAdvertisementById(Guid id)
        {
            return context.Advertisements.FirstOrDefault(x => x.AdvertisementId == id);
        }
        public void SaveAdvertisement(Advertisement advertisement)
        {
            if (advertisement.AdvertisementId == default)
            {
                advertisement.AdvertisementId = Guid.NewGuid();
                context.Entry(advertisement).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            else
                context.Entry(advertisement).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteAdvertisement(Guid PersonId)
        {
            var adv = GetAdvertisementById(PersonId);
            if (adv != null)
            {
                context.Advertisements.Remove(adv);
            }
        }
    }
}
