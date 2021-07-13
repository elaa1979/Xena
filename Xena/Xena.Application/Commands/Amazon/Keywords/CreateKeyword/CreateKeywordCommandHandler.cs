using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Xena.Application.Abstractions.Repositories;
using Xena.Application.Utils;
using Xena.Domain.Amazon;
using MediatR;

namespace Xena.Application.Commands.Amazon.Keywords.CreateKeyword
{
    public class CreateKeywordCommandHandler : IRequestHandler<CreateKeywordCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly UserHelper _userHelper;
        public CreateKeywordCommandHandler(IUnitOfWork uow, IMapper mapper, UserHelper userHelper)
        {
            _uow = uow;
            _mapper = mapper;
            _userHelper = userHelper;
        }
        public async Task<Unit> Handle(CreateKeywordCommand request, CancellationToken cancellationToken)
        {
            var keyword = _mapper.Map<AmazonKeyword>(request);
            keyword.UserId = _userHelper.GetUserId();
            await _uow.GetReposiotory<AmazonKeyword>().AddAsync(keyword);
            await _uow.CompleteAsync();

            return Unit.Value;
        }
    }
}