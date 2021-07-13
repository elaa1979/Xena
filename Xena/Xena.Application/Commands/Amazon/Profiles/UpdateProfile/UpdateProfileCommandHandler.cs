using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Xena.Application.Abstractions.Repositories;
using Xena.Application.Common.Exceptions;
using Xena.Application.Utils;
using Xena.Domain.Amazon;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Xena.Application.Commands.Amazon.Profiles.UpdateProfile
{
    public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly UserHelper _userHelper;
        public UpdateProfileCommandHandler(IUnitOfWork uow, IMapper mapper, UserHelper userHelper)
        {
            _uow = uow;
            _mapper = mapper;
            _userHelper = userHelper;
        }
        public async Task<Unit> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            var profile = await _uow.GetReposiotory<AmazonProfile>().GetAsync(request.profileId);

            if (profile is null)
                throw new BadRequestException(ErrorCodes.UserNotExists);

            if (_userHelper.GetUserId() != profile.UserId)
                throw new ForbiddenException(ErrorCodes.Forbidden);

            profile = _mapper.Map<UpdateProfileCommand, AmazonProfile>(request, profile);
            await _uow.CompleteAsync();

            return Unit.Value;
        }
    }
}