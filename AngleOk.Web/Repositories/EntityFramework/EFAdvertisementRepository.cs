using AngleOk.Web.Repositories.Abstract;
using Data.AngleOk.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace AngleOk.Web.Repositories.EntityFramework
{
    public class EfAdvertisementRepository(AngleOkContext context) : IAdvertisementRepository
    {
        public IQueryable<Advertisement> GetAll() 
        {
            var ads= context.Advertisements.Include(i => i.RealtyObject).ThenInclude(i => i!.TitleImage);
			return ads; 
        }
        public Advertisement? GetAdvertisementById(Guid id)
        {
            return context.Advertisements
                .Include(i=>i.Manager)
                .FirstOrDefault(x => x.Id == id);
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