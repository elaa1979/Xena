using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Xena.Application.Abstractions.Repositories;
using Xena.Application.Utils;
using Xena.Domain.Amazon;
using MediatR;

namespace Xena.Application.Commands.Amazon.Profiles.CreateProfile
{
    public class CreateProfileCommandHandler : IRequestHandler<CreateProfileCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly UserHelper _userHelper;
        public CreateProfileCommandHandler(IUnitOfWork uow, IMapper mapper, UserHelper userHelper)
        {
            _uow = uow;
            _mapper = mapper;
            _userHelper = userHelper;
        }
        public async Task<Unit> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
        {
            var profile = _mapper.Map<AmazonProfile>(request);
            profile.UserId = _userHelper.GetUserId();
            await _uow.GetReposiotory<AmazonProfile>().AddAsync(profile);
            await _uow.CompleteAsync();

            return Unit.Value;
        }
    }
}