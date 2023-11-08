using AngleOk.Web.Repositories.Abstract;
using Data.AngleOk.Model.Models;

namespace AngleOk.Web.Repositories.EntityFramework
{
    public class EFEmployeeRepository:IEmployeeRepository
    {
        private readonly AngleOkContext context;
        public EFEmployeeRepository(AngleOkContext context) { this.context = context; }
        public IQueryable<Employee> GetAll() { return context.Employees; }

        public Employee? GetEmployeeByName(string name)
        {
            return context.Employees.FirstOrDefault(x => x.Person.Email == name);
        }

        public Employee? GetEmployeeById(Guid id)
        {
            return context.Employees.FirstOrDefault(x => x.PersonId == id);
        }
        public void SaveEmployee(Employee person)
        {
            if (person.PersonId == null)
            {
                person.PersonId = Guid.NewGuid();
                context.Entry(person).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            else
                context.Entry(person).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteEmployee(Guid PersonId)
        {
            context.Employees.Remove(GetEmployeeById(PersonId));
        }
    }
}
