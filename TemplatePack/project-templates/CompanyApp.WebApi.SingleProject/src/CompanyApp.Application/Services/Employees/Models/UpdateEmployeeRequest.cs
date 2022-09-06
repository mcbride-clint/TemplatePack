using CompanyApp.Application.Domain.Models;

namespace CompanyApp.Application.Services.Employees.Models
{
    public class UpdateEmployeeRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }

        internal void Transfer(Employee e)
        {
            if (FirstName != null) e.FirstName = FirstName;
            if (LastName != null) e.LastName = LastName;
            if (Email != null) e.Email = Email;
            if (PhoneNumber != null) e.PhoneNumber = PhoneNumber;
            if (HireDate != null) e.HireDate = HireDate.Value;
            if (TerminationDate != null) e.TerminationDate = TerminationDate;
        }
    }
}
