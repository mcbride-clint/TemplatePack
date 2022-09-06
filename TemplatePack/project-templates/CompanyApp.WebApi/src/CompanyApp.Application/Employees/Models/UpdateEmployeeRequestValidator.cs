using FluentValidation;

namespace CompanyApp.Application.Employees.Models
{
    public class UpdateEmployeeRequestValidator : AbstractValidator<UpdateEmployeeRequest>
    {
        public UpdateEmployeeRequestValidator()
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email is not valid");
            RuleFor(x => x.PhoneNumber).Matches(@"^\d{10}$").WithMessage("Phone number is not valid");
        }
    }
}
