using FluentValidation;
using perpusapi.DataModel;

namespace perpusapi.Validator 
{
    public class BookMemberValidator : AbstractValidator<BookMember> 
    {
        public BookMemberValidator()
        {
            RuleFor(m => m.BookId).NotEmpty();
            RuleFor(m => m.MemberId).NotEmpty();
            RuleFor(m => m.BorrowDate).NotEmpty();
        }

    }
}