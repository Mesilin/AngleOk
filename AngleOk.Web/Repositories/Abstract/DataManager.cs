namespace AngleOk.Web.Repositories.Abstract
{
    public class DataManager(ITextFieldsRepository textFieldsRepository, 
        IAdvertisementRepository adv, 
        IClientsRepository clients, 
        IEmployeeRepository employee,
        IRealtyObjectsRepository realtyObject)
    {
        public IAdvertisementRepository Advertisements { get;set; } = adv;
        public ITextFieldsRepository TextFields { get; set; } = textFieldsRepository;
        public IClientsRepository Clients { get; set; } = clients;
        public IEmployeeRepository Employee { get; set; } = employee;
        public IRealtyObjectsRepository RealtyObject { get; set; } = realtyObject;
    }
}
