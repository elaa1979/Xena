using MediatR;
using System.Collections.Generic;

namespace Xena.Application.Queries.Amazon.Profiles.GetProfile
{
    public class GetProfileQuery : IRequest<ProfileDto>
    {
        public long Id { get; set; }
    }
}