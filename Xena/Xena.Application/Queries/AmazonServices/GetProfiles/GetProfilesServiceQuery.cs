using MediatR;
using System.Collections.Generic;

namespace Xena.Application.Queries.AmazonServices.GetProfiles
{
    public class GetProfilesServiceQuery : IRequest<List<ProfileDto>>
    {
        public bool SyncDB { get; set; }
    }
}