
using FluentValidation;

namespace TaskAndTeamManagement.Application.Dtos.UserManagement
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Full Name is required.")
                .Length(2, 50).WithMessage("Full Name must be between 2 and 50 characters.");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.Role)
                .IsInEnum().WithMessage("Invalid role.");
        }
    }
}
