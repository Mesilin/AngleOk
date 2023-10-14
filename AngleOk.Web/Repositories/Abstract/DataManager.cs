using Data.AngleOk.Model.Models;

namespace AngleOk.Web.Repositories.Abstract
{
    public class DataManager
    {
        //public IPersonsRepository Persons { get;set; }
        public IAdvertisementRepository Advertisements { get;set; }

        //public DataManager(IPersonsRepository persons) {
        //    Persons = persons;
        //}
        public DataManager(IAdvertisementRepository adv)
        {
            Advertisements = adv;
        }
    }
}
