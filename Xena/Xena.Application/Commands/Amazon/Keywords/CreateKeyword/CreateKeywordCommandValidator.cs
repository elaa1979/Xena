using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Xena.Application.Abstractions.Repositories;
using Xena.Application.Common.Exceptions;
using Xena.Application.Utils;
using Xena.Domain.Amazon;

namespace Xena.Application.Commands.Amazon.Keywords.CreateKeyword
{
    public class CreateKeywordCommandValidator : AbstractValidator<CreateKeywordCommand>
    {
        private readonly IUnitOfWork _uow;
        public CreateKeywordCommandValidator(IUnitOfWork uow)
        {
            _uow = uow;
        }
        
    }
}