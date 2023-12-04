using Data.AngleOk.Model.Models;

namespace AngleOk.Web.Repositories.Abstract
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> GetAll();
        Employee? GetEmployeeById(Guid EmployeeId);
        void SaveEmployee(Employee employee);
        void DeleteEmployee(Guid EmployeeId);
        Employee? GetEmployeeByName(string? name);
    }
}
