namespace AngleOk.Web.Repositories.Abstract
{
    public class DataManager
    {
        public IAdvertisementRepository Advertisements { get;set; }
        public ITextFieldsRepository TextFields { get; set; }
        public IClientsRepository Clients { get; set; }
        public IEmployeeRepository Employee { get; set; }
        public IRealtyObjectsRepository RealtyObject { get; set; }

        public DataManager(
            ITextFieldsRepository textFieldsRepository, 
            IAdvertisementRepository adv, 
            IClientsRepository clients, 
            IEmployeeRepository employee,
            IRealtyObjectsRepository realtyObject)
        {
            TextFields = textFieldsRepository;
            Advertisements = adv;
            Clients = clients;
            Employee = employee;
            RealtyObject = realtyObject;
        }
    }
}
