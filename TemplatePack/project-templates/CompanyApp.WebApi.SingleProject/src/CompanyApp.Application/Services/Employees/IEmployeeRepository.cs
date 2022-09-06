using CompanyApp.Application.Services.Employees.Models;
using CompanyApp.Application.Domain.Models;

namespace CompanyApp.Application.Services.Employees
{
    public interface IEmployeeRepository
    {
        Employee Create(Employee employee);
        int Delete(int id);
        IEnumerable<Employee> Get(EmployeeFilter? filter);
        Employee Update(Employee employee);
    }
}
