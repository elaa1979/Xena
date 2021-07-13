using MediatR;
using System.Collections.Generic;

namespace Xena.Application.Queries.Amazon.Profiles.GetProfiles
{
    public class GetProfilesQuery : IRequest<List<ProfileDto>>
    {
        public bool Nocache { get; set; }
    }
}