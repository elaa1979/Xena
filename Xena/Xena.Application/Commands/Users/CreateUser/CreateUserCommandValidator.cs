using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Xena.Application.Abstractions.Repositories;
using Xena.Application.Common.Exceptions;
using Xena.Application.Utils;
using Xena.Domain.Users;

namespace Xena.Application.Commands.Users.Register
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IUnitOfWork _uow;
        public CreateUserCommandValidator(IUnitOfWork uow)
        {
            _uow = uow;

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage(ErrorCodes.EmailNotValid)
                .MustAsync(beUnique)
                .WithMessage(ErrorCodes.EmailAlreadyExists);

            RuleFor(x => x.Password)
                .Password();

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password)
                .WithMessage(ErrorCodes.PasswordsNotMatch);

            RuleFor(x => x.Phone)
                .Matches(@"^(\+\d{1,2}(\s)?)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$")
                .WithMessage(ErrorCodes.InvalidPhoneNumber);
        }
        private async Task<bool> beUnique(string property, CancellationToken cancellationToken)
        {
            var exists = await _uow.GetReposiotory<User>().GetByAsync(x => x.Email == property);
            return exists is null;
        }
    }
}