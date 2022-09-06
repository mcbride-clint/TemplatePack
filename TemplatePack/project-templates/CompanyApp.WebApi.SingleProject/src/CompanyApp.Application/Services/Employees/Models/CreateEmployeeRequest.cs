using CompanyApp.Application.Domain.Models;

namespace CompanyApp.Application.Services.Employees.Models
{
    public class CreateEmployeeRequest
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public DateTime HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }

        internal Employee ToEmployee()
        {
            var e = new Employee();
            e.FirstName = FirstName;
            e.LastName = LastName;
            e.Email = Email;
            e.PhoneNumber = PhoneNumber;
            e.HireDate = HireDate;
            e.TerminationDate = TerminationDate;

            return e;
        }
    }
}
