using CompanyApp.Application.Domain.Models;

namespace CompanyApp.Application.Infrastructure.Persistance.InMemory
{
    public class InMemoryEmployeeDataStore
    {
        public readonly List<Employee> Employees = new();
        public InMemoryEmployeeDataStore()
        {
            // Populate Employee List with Default Entries            
            if (Employees.Count == 0)
            {
                Employees.Add(new Employee() { Id = Employees.Count, FirstName = "John", LastName = "Smith", Email = "john.smith@gmail.com", PhoneNumber = "1234567890", HireDate = DateTime.Now.AddYears(-5).AddMonths(2) });
                Employees.Add(new Employee() { Id = Employees.Count, FirstName = "Will", LastName = "Smith", Email = "will.smith@gmail.com", PhoneNumber = "1234567891", HireDate = DateTime.Now.AddYears(-4).AddMonths(-3) });
                Employees.Add(new Employee() { Id = Employees.Count, FirstName = "Will", LastName = "Nike", Email = "will.nike@gmail.com", PhoneNumber = "1234567892", HireDate = DateTime.Now.AddYears(-3).AddMonths(1), TerminationDate = DateTime.Now.AddMonths(-3) });
                Employees.Add(new Employee() { Id = Employees.Count, FirstName = "William", LastName = "Jones", Email = "john.smith@gmail.com", PhoneNumber = "1234567893", HireDate = DateTime.Now.AddYears(-2).AddMonths(-2) });
                Employees.Add(new Employee() { Id = Employees.Count, FirstName = "Kevin", LastName = "Smith", Email = "kevin.smith@gmail.com", PhoneNumber = "1234567894", HireDate = DateTime.Now.AddYears(-1).AddMonths(5) });
            }
        }
    }
}
