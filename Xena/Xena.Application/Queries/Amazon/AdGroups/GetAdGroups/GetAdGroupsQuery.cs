using MediatR;
using System.Collections.Generic;

namespace Xena.Application.Queries.Amazon.AdGroups.GetAdGroups
{
    public class GetAdGroupsQuery : IRequest<List<AdGroupDto>>
    {
        public long ProfileId { get; set; }
        public bool Nocache { get; set; }
    }
}