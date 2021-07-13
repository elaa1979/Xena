using MediatR;
using System.Collections.Generic;

namespace Xena.Application.Queries.AmazonServices.GetAdGroups
{
    public class GetAdGroupsServiceQuery : IRequest<List<AdGroupDto>>
    {
        public long ProfileId { get; set; }
        public bool SyncDB { get; set; }
    }
}