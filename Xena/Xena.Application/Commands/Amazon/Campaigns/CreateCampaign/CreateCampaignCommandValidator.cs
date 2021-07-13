using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Xena.Application.Abstractions.Repositories;
using Xena.Application.Common.Exceptions;
using Xena.Application.Utils;
using Xena.Domain.Amazon;

namespace Xena.Application.Commands.Amazon.Campaigns.CreateCampaign
{
    public class CreateCampaignCommandValidator : AbstractValidator<CreateCampaignCommand>
    {
        private readonly IUnitOfWork _uow;
        public CreateCampaignCommandValidator(IUnitOfWork uow)
        {
            _uow = uow;
        }
        
    }
}