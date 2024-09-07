using Data.AngleOk.Model.Models;

namespace AngleOk.Web.Repositories.Abstract
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> GetAll();
        Employee? GetEmployeeById(Guid employeeId);
        void SaveEmployee(Employee employee);
        void DeleteEmployee(Guid employeeId);
        Employee? GetEmployeeByName(string? name);
    }
}
