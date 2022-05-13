using CompanyApp.Application.Employees.Models;
using CompanyApp.Domain.Models;

namespace CompanyApp.Application.Employees
{
    public interface IEmployeeRepository
    {
        Employee Create(Employee employee);
        int Delete(int id);
        IEnumerable<Employee> Get(EmployeeFilter? filter);
        Employee Update(Employee employee);
    }
}