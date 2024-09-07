using AngleOk.Web.Repositories.Abstract;
using Data.AngleOk.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace AngleOk.Web.Repositories.EntityFramework
{
    public class EFAdvertisementRepository : IAdvertisementRepository
    {
        private readonly AngleOkContext context;
        public EFAdvertisementRepository(AngleOkContext context) { this.context = context; }
        public IQueryable<Advertisement> GetAll() 
        {
            return context.Advertisements.Include(i=>i.RealtyObject).ThenInclude(i=>i.TitleImage); 
        }
        public Advertisement? GetAdvertisementById(Guid id)
        {
            return context.Advertisements
                .Include(i=>i.Manager)
                .FirstOrDefault(x => x.Id == id);
        }

        public Guid CreateAdvertisement(Advertisement advertisement)
        {
            if (advertisement.Id == default)
            {
                advertisement.Id = Guid.NewGuid();
            }

            context.Entry(advertisement).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            context.SaveChanges();
            return advertisement.Id;
        }

        public void SaveAdvertisement(Advertisement advertisement)
        {
            if (advertisement.Id == default)
            {
                advertisement.Id = Guid.NewGuid();
                context.Entry(advertisement).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            else
                context.Entry(advertisement).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteAdvertisement(Guid advertisementId)
        {
            var adv = GetAdvertisementById(advertisementId);
            if (adv != null)
            {
                context.Advertisements.Remove(adv);
            }
        }
    }
}
