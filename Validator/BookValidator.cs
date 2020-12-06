using FluentValidation;
using perpusapi.DataModel;

namespace perpusapi.Validator {
    public class BookValidator : AbstractValidator<Book> {

        public BookValidator()
        {
            RuleFor(m => m.Title).NotEmpty();
            RuleFor(m => m.Author).NotEmpty();
            RuleFor(m => m.PublishedDate).NotEmpty();
        }

    }
}