using System.Threading;
using System.Threading.Tasks;
using Xena.Application.Abstractions.Repositories;
using Xena.Application.Common.Exceptions;
using Xena.Application.Utils;
using Xena.Domain.Amazon;
using MediatR;

namespace Xena.Application.Commands.Amazon.Campaigns.DeleteCampaign
{
    public class DeleteCampaignCommandHandler : IRequestHandler<DeleteCampaignCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly UserHelper _userHelper;
        public DeleteCampaignCommandHandler(IUnitOfWork uow, UserHelper userHelper)
        {
            _uow = uow;
            _userHelper = userHelper;
        }
        
        public async Task<Unit> Handle(DeleteCampaignCommand request, CancellationToken cancellationToken)
        {
            //var repo = _uow.GetReposiotory<AmazonCampaign>();
            //var profile = await repo.GetAsync(request.Id);
            //if (profile == null)
            //    throw new BadRequestException(ErrorCodes.VaultNotExists);

            //if (_userHelper.GetUserId() != profile.UserId)
            //    throw new ForbiddenException(ErrorCodes.Forbidden);

            //repo.Remove(profile);
            //await _uow.CompleteAsync();

            return Unit.Value;
        }
    }
}