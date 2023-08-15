using FluentValidation;

namespace Application.Dtos.Validations
{
    public class UpdateArticleDtoValidator : AbstractValidator<UpdateArticleDto>
    {
        public UpdateArticleDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("Field Id is mandatory!");

        }
    }
}
