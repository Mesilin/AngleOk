using Data.AngleOk.Model.Models;

namespace AngleOk.Web.Repositories.Abstract
{
    public class DataManager
    {
        public IAdvertisementRepository Advertisements { get;set; }
        public ITextFieldsRepository TextFields { get; set; }

        //public DataManager(IPersonsRepository persons) {
        //    Persons = persons;
        //}
        public DataManager(ITextFieldsRepository textFieldsRepository, IAdvertisementRepository adv)
        {
            TextFields = textFieldsRepository;
            Advertisements = adv;

        }
    }
}
