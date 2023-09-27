using Data.AngleOk.Model.Models;

namespace AngleOk.Web.Repositories.Abstract
{
    public interface IPersonsRepository
    {
        IQueryable<Person> GetAll();
        Person GetPersonById(Guid PersonId);
        void SavePerson(Person person);
        void DeletePerson(Guid PersonId);
    }
}
