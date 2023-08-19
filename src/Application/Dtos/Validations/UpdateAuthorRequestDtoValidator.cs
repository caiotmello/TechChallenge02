using Application.Dtos.Request;
using FluentValidation;

namespace Application.Dtos.Validations
{
    public class UpdateAuthorRequestDtoValidator : AbstractValidator<UpdateAuthorRequestDto>
    {
        public UpdateAuthorRequestDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("Field Id is mandatory!");

        }
    }
}
