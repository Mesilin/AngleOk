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
            return context.Employees.FirstOrDefault(x => x.Email == name);
        }

        public Employee? GetEmployeeById(Guid id)
        {
            return context.Employees.FirstOrDefault(x => x.Id == id);
        }
        public void SaveEmployee(Employee employee)
        {
            if (employee.Id == null|| employee.Id == default)
            {
                employee.Id = Guid.NewGuid();
                context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            else
                context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteEmployee(Guid employeeId)
        {
            context.Employees.Remove(GetEmployeeById(employeeId));
        }
    }
}
