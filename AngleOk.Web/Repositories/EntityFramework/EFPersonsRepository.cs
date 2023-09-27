using AngleOk.Web.Repositories.Abstract;
using Data.AngleOk.Model.Models;

namespace AngleOk.Web.Repositories.EntityFramework
{
    public class EFPersonsRepository:IPersonsRepository
    {
        private readonly AngleOkContext context;
        public EFPersonsRepository(AngleOkContext context) { this.context = context; }
        public IQueryable<Person> GetAll() {return context.Persons;}
        public Person GetPersonById(Guid id)
        {
            //return context.Persons.SingleOrDefault(x => x.PersonId == id);
            return context.Persons.FirstOrDefault(x => x.PersonId == id);
        }
        public void SavePerson(Person person)
        {
            if(person.PersonId==null)
            {
                person.PersonId = Guid.NewGuid();
                context.Entry(person).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            else
                context.Entry(person).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
        public void DeletePerson(Guid PersonId)
        {
            context.Persons.Remove(GetPersonById(PersonId));
        }
    }
}
