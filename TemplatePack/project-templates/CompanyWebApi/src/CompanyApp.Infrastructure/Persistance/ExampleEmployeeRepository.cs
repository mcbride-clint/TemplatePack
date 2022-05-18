using CompanyApp.Application.Employees;
using CompanyApp.Application.Employees.Models;
using CompanyApp.Domain.Models;

namespace CompanyApp.Infrastructure.Persistance
{
    /// <summary>
    /// Example In-Memory Repository
    /// </summary>
    public class ExampleEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employeeList = new();
        public ExampleEmployeeRepository()
        {
            // Populate Employee List with Default Entries            
            if (_employeeList.Count == 0)
            {
                _employeeList.Add(new Employee() { Id = _employeeList.Count, FirstName = "John", LastName = "Smith", Email = "john.smith@gmail.com", PhoneNumber = "1234567890", HireDate = DateTime.Now.AddYears(-5).AddMonths(2) });
                _employeeList.Add(new Employee() { Id = _employeeList.Count, FirstName = "Will", LastName = "Smith", Email = "will.smith@gmail.com", PhoneNumber = "1234567891", HireDate = DateTime.Now.AddYears(-4).AddMonths(-3) });
                _employeeList.Add(new Employee() { Id = _employeeList.Count, FirstName = "Will", LastName = "Nike", Email = "will.nike@gmail.com", PhoneNumber = "1234567892", HireDate = DateTime.Now.AddYears(-3).AddMonths(1), TerminationDate = DateTime.Now.AddMonths(-3) });
                _employeeList.Add(new Employee() { Id = _employeeList.Count, FirstName = "William", LastName = "Jones", Email = "john.smith@gmail.com", PhoneNumber = "1234567893", HireDate = DateTime.Now.AddYears(-2).AddMonths(-2) });
                _employeeList.Add(new Employee() { Id = _employeeList.Count, FirstName = "Kevin", LastName = "Smith", Email = "kevin.smith@gmail.com", PhoneNumber = "1234567894", HireDate = DateTime.Now.AddYears(-1).AddMonths(5) });
            }
        }

        public IEnumerable<Employee> Get(EmployeeFilter? filter)
        {
            IEnumerable<Employee> result = _employeeList;

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
            employee.Id = _employeeList.Count;
            _employeeList.Add(employee);

            return employee;
        }

        public Employee Update(Employee employee)
        {
            var existingEmployee = _employeeList.SingleOrDefault(e => e.Id == employee.Id);

            if (existingEmployee is not null)
            {
                _employeeList.Remove(existingEmployee);
                _employeeList.Add(employee);
                return employee;
            }

            throw new KeyNotFoundException($"Employee with Id: {employee.Id} not found.");
        }

        public int Delete(int id)
        {
            var existingEmployee = _employeeList.SingleOrDefault(e => e.Id == id);

            if (existingEmployee is not null)
            {
                _employeeList.Remove(existingEmployee);
                return 1;
            }

            return 0;
        }
    }
}