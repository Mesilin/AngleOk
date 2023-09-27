namespace AngleOk.Web.Repositories.Abstract
{
    public class DataManager
    {
        public IPersonsRepository Persons { get;set; }

        public DataManager(IPersonsRepository persons) {
            Persons = persons;
        }
    }
}
