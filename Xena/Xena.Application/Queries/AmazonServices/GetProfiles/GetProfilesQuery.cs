using MediatR;
using System.Collections.Generic;

namespace Xena.Application.Queries.AmazonServices.GetProfiles
{
    public class GetProfilesQuery : IRequest<List<ProfileDto>>
    {
    }
}