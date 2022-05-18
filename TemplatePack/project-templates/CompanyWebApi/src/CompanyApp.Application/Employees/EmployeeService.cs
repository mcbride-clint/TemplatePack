using CompanyApp.Application.Employees.Models;
using CompanyApp.Domain.Models;

namespace CompanyApp.Application.Employees
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository employeeRepo;

        public EmployeeService(IEmployeeRepository employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }

        public IEnumerable<Employee> GetEmployees(EmployeeFilter? filter)
        {
            return employeeRepo.Get(filter);
        }

        public Employee CreateEmployee(CreateEmployeeRequest request)
        {
            // Validate Request
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            // Create Employee Model
            var newEmployee = request.ToEmployee();

            // Save Employee
            return employeeRepo.Create(newEmployee);
        }

        public Employee UpdateEmployee(int id, UpdateEmployeeRequest request)
        {
            // Validate Request
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var existingEmployee = employeeRepo.Get(new EmployeeFilter() { Id = id }).SingleOrDefault();

            if (existingEmployee == null)
            {
                throw new ArgumentException("Employee does not exist");
            }

            // Update Employee Model
            request.Transfer(existingEmployee);

            // Save Employee
            return employeeRepo.Update(existingEmployee);
        }

        public Employee TerminateEmployee(int id)
        {
            var request = new UpdateEmployeeRequest()
            {
                TerminationDate = DateTime.Now
            };

            return UpdateEmployee(id, request);
        }

        public int DeleteEmployee(int id)
        {
            var existingEmployee = employeeRepo.Get(new EmployeeFilter() { Id = id }).SingleOrDefault(); ;

            if (existingEmployee == null)
            {
                throw new ArgumentException("Employee does not exist");
            }

            return employeeRepo.Delete(id);
        }
    }
}
