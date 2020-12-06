using FluentValidation;
using perpusapi.DataModel;

namespace perpusapi.Validator
{
    public class MemberValidator : AbstractValidator<Member>
    {
        public MemberValidator()
        {
            RuleFor(m => m.Name).NotEmpty();
            RuleFor(m => m.PhoneNumber).NotEmpty();
            RuleFor(m => m.Address).NotEmpty();
        }

    }
}