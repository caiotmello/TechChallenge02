using Application.Dtos.Request;
using FluentValidation;

namespace Application.Dtos.Validations
{
    public class CreateCategoryRequestDtoValidator :AbstractValidator<CreateCategoryRequestDto>
    {
        public CreateCategoryRequestDtoValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty()
               .NotNull()
               .WithMessage("Field Name is mandatory!");
        }
    }
}
