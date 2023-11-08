using Data.AngleOk.Model.Models;

namespace AngleOk.Web.Repositories.Abstract
{
    public class DataManager
    {
        public IAdvertisementRepository Advertisements { get;set; }
        public ITextFieldsRepository TextFields { get; set; }
        public IPersonsRepository Persons { get; set; }
        public IEmployeeRepository Employee { get; set; }

        public DataManager(ITextFieldsRepository textFieldsRepository, IAdvertisementRepository adv, IPersonsRepository persons, IEmployeeRepository employee)
        {
            TextFields = textFieldsRepository;
            Advertisements = adv;
            Persons = persons;
            Employee = employee;
        }
    }
}
