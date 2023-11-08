using Data.AngleOk.Model.Models;

namespace AngleOk.Web.Repositories.Abstract
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> GetAll();
        Employee? GetEmployeeById(Guid PersonId);
        void SaveEmployee(Employee person);
        void DeleteEmployee(Guid PersonId);
        Employee? GetEmployeeByName(string? name);
    }
}
