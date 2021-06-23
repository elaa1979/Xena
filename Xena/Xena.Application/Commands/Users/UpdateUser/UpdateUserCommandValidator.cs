using FluentValidation;
using Xena.Application.Common.Exceptions;

namespace Xena.Application.Commands.Users.UpdateUser
{
    public class UpdateUserCommandValidator:AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Phone)
                .Matches(@"^(\+\d{1,2}(\s)?)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$")
                .WithMessage(ErrorCodes.InvalidPhoneNumber);
        }
    }
}