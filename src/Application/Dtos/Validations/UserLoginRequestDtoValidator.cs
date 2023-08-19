using Application.Dtos.Request;
using FluentValidation;

namespace Application.Dtos.Validations
{
    public class UserLoginRequestDtoValidator : AbstractValidator<UserLoginRequestDto>
    {
        public UserLoginRequestDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull().WithMessage("Field Email is mandatory!")
                .EmailAddress().WithMessage("The Field {PropertyName} is invalid!");

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("Field Password is mandatory!");
                
        }
    }
}
