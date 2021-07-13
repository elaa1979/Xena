using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Xena.Application.Abstractions.Repositories;
using Xena.Application.Common.Exceptions;
using Xena.Application.Utils;
using Xena.Domain.Amazon;

namespace Xena.Application.Commands.Amazon.AdGroups.CreateAdGroup
{
    public class CreateAdGroupCommandValidator : AbstractValidator<CreateAdGroupCommand>
    {
        private readonly IUnitOfWork _uow;
        public CreateAdGroupCommandValidator(IUnitOfWork uow)
        {
            _uow = uow;
        }
        
    }
}