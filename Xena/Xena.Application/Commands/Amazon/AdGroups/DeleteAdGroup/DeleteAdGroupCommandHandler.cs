using System.Threading;
using System.Threading.Tasks;
using Xena.Application.Abstractions.Repositories;
using Xena.Application.Common.Exceptions;
using Xena.Application.Utils;
using Xena.Domain.Amazon;
using MediatR;

namespace Xena.Application.Commands.Amazon.AdGroups.DeleteAdGroup
{
    public class DeleteAdGroupCommandHandler : IRequestHandler<DeleteAdGroupCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly UserHelper _userHelper;
        public DeleteAdGroupCommandHandler(IUnitOfWork uow, UserHelper userHelper)
        {
            _uow = uow;
            _userHelper = userHelper;
        }
        
        public async Task<Unit> Handle(DeleteAdGroupCommand request, CancellationToken cancellationToken)
        {
            //var repo = _uow.GetReposiotory<AmazonAdGroup>();
            //var adGroup = await repo.GetAsync(request.Id);
            //if (adGroup == null)
            //    throw new BadRequestException(ErrorCodes.VaultNotExists);

            //if (_userHelper.GetUserId() != adGroup.UserId)
            //    throw new ForbiddenException(ErrorCodes.Forbidden);

            //repo.Remove(adGroup);
            //await _uow.CompleteAsync();

            return Unit.Value;
        }
    }
}