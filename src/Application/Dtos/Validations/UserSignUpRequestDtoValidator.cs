using Application.Dtos.Request;
using FluentValidation;

namespace Application.Dtos.Validations
{
    public class UserSignUpRequestDtoValidator : AbstractValidator<UserSignUpRequestDto>
    {
        public UserSignUpRequestDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull().WithMessage("Field Email is mandatory!")
                .EmailAddress().WithMessage("The Field {PropertyName} is invalid!"); ;

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull().WithMessage("Field Password is mandatory!")
                .Length(6, 50).WithMessage("The Field {0} must have between  {2} and {1} caractheres!");

            RuleFor(x => x.PasswordConfirmation)
                .NotEmpty()
                .NotNull().WithMessage("Field Password Confirmation is mandatory!")
                .Equal(x => x.Password).WithMessage("The password must be the same!");
        }
    }
}
