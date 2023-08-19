using Application.Dtos.Request;
using FluentValidation;

namespace Application.Dtos.Validations
{
    public class UpdateArticleRequestDtoValidator : AbstractValidator<UpdateArticleRequestDto>
    {
        public UpdateArticleRequestDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("Field Id is mandatory!");

        }
    }
}
