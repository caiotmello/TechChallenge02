using Application.Dtos.Request;
using FluentValidation;

namespace Application.Dtos.Validations
{
    public class CreateAuthorRequestDtoValidator : AbstractValidator<CreateAuthorRequestDto>
    {
        public CreateAuthorRequestDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Field Name is mandatory!");

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull().WithMessage("Field Content is mandatory!")
                .EmailAddress().WithMessage("The Field {PropertyName} is invalid!");

        }
    }
}
