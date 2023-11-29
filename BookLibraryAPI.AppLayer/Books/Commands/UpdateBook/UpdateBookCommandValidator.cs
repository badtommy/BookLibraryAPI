using FluentValidation;

namespace BookLibraryAPI.AppLayer.Books.Commands.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(250);

            RuleFor(x => x.Author)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.ISBN)
                .NotEmpty()
                .MaximumLength(16)
                 .WithMessage("ISBN nesmí být delší než 16 znaků.");
        }
    }
}
