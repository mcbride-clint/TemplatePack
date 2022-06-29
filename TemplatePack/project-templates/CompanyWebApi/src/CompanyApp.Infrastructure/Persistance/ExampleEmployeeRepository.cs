using CompanyApp.Application.Employees;
using CompanyApp.Application.Employees.Models;
using CompanyApp.Domain.Models;
using CompanyApp.Infrastructure.Persistance.InMemory;

namespace CompanyApp.Infrastructure.Persistance
{
    /// <summary>
    /// Example In-Memory Repository
    /// </summary>
    public class ExampleEmployeeRepository : IEmployeeRepository
    {
        private readonly InMemoryEmployeeDataStore _inMemoryEmployeeData;

        public ExampleEmployeeRepository(InMemoryEmployeeDataStore inMemoryEmployeeData)
        {
            _inMemoryEmployeeData = inMemoryEmployeeData;
        }

        public IEnumerable<Employee> Get(EmployeeFilter? filter)
        {
            IEnumerable<Employee> result = _inMemoryEmployeeData.Employees;

            if (filter != null)
            {
                if (filter.Id != null)
                {
                    result = result.Where(x => x.Id == filter.Id);
                }
                if (filter.FirstName != null)
                {
                    result = result.Where(x => x.FirstName == filter.FirstName);
                }
                if (filter.LastName != null)
                {
                    result = result.Where(x => x.LastName == filter.LastName);
                }
                if (filter.Email != null)
                {
                    result = result.Where(x => x.Email == filter.Email);
                }
                if (filter.PhoneNumber != null)
                {
                    result = result.Where(x => x.PhoneNumber == filter.PhoneNumber);
                }
                if (filter.HireDate != null)
                {
                    result = result.Where(x => x.HireDate == filter.HireDate);
                }
                if (filter.TerminationDate != null)
                {
                    result = result.Where(x => x.TerminationDate == filter.TerminationDate);
                }
            }

            return result;
        }

        public Employee Create(Employee employee)
        {
            employee.Id = _inMemoryEmployeeData.Employees.Count;
            _inMemoryEmployeeData.Employees.Add(employee);

            return employee;
        }

        public Employee Update(Employee employee)
        {
            var existingEmployee = _inMemoryEmployeeData.Employees.SingleOrDefault(e => e.Id == employee.Id);

            if (existingEmployee is not null)
            {
                _inMemoryEmployeeData.Employees.Remove(existingEmployee);
                _inMemoryEmployeeData.Employees.Add(employee);
                return employee;
            }

            throw new KeyNotFoundException($"Employee with Id: {employee.Id} not found.");
        }

        public int Delete(int id)
        {
            var existingEmployee = _inMemoryEmployeeData.Employees.SingleOrDefault(e => e.Id == id);

            if (existingEmployee is not null)
            {
                _inMemoryEmployeeData.Employees.Remove(existingEmployee);
                return 1;
            }

            return 0;
        }
    }
}
