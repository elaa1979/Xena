using MediatR;
using System.Collections.Generic;

namespace Xena.Application.Queries.AmazonServices.GetAdGroups
{
    public class GetAdGroupsQuery : IRequest<List<AdGroupDto>>
    {
        public long ProfileId { get; set; }
    }
}