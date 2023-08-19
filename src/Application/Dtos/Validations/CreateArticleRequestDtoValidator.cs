using Application.Dtos.Request;
using FluentValidation;

namespace Application.Dtos.Validations
{
    public class CreateArticleRequestDtoValidator :AbstractValidator<CreateArticleRequestDto>
    {
        public CreateArticleRequestDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("Field Title is mandatory!");

            RuleFor(x => x.Content)
                .NotEmpty()
                .NotNull()
                .WithMessage("Field Content is mandatory!");

            RuleFor(x => x.AuthorId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Field AuthorId is mandatory!");

            RuleFor(x => x.CategoryId)
               .NotEmpty()
               .NotNull()
               .WithMessage("Field CategoryId is mandatory!");
        }
    }
}
