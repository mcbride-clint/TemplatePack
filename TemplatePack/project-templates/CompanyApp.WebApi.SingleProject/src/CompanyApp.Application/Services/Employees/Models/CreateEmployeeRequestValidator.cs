using FluentValidation;

namespace CompanyApp.Application.Services.Employees.Models
{
    public class CreateEmployeeRequestValidator : AbstractValidator<CreateEmployeeRequest>
    {
        public CreateEmployeeRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email is not valid");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required");
            RuleFor(x => x.PhoneNumber).Matches(@"^\d{10}$").WithMessage("Phone number is not valid");
            RuleFor(x => x.HireDate).NotEmpty().WithMessage("Hire date is required");
        }
    }
}
