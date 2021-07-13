using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Xena.Application.Abstractions.Repositories;
using Xena.Application.Common.Exceptions;
using Xena.Application.Utils;
using Xena.Domain.Amazon;

namespace Xena.Application.Commands.Amazon.Profiles.CreateProfile
{
    public class CreateProfileCommandValidator : AbstractValidator<CreateProfileCommand>
    {
        private readonly IUnitOfWork _uow;
        public CreateProfileCommandValidator(IUnitOfWork uow)
        {
            _uow = uow;
        }
        
    }
}