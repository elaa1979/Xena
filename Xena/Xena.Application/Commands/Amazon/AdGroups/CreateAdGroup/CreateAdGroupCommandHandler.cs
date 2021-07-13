using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Xena.Application.Abstractions.Repositories;
using Xena.Application.Utils;
using Xena.Domain.Amazon;
using MediatR;

namespace Xena.Application.Commands.Amazon.AdGroups.CreateAdGroup
{
    public class CreateAdGroupCommandHandler : IRequestHandler<CreateAdGroupCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly UserHelper _userHelper;
        public CreateAdGroupCommandHandler(IUnitOfWork uow, IMapper mapper, UserHelper userHelper)
        {
            _uow = uow;
            _mapper = mapper;
            _userHelper = userHelper;
        }
        public async Task<Unit> Handle(CreateAdGroupCommand request, CancellationToken cancellationToken)
        {
            var adGroup = _mapper.Map<AmazonAdGroup>(request);
            adGroup.UserId = _userHelper.GetUserId();
            await _uow.GetReposiotory<AmazonAdGroup>().AddAsync(adGroup);
            await _uow.CompleteAsync();

            return Unit.Value;
        }
    }
}