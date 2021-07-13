using MediatR;
using System.Collections.Generic;

namespace Xena.Application.Queries.Amazon.AdGroups.GetAdGroup
{
    public class GetAdGroupQuery : IRequest<AdGroupDto>
    {
        public long Id { get; set; }
    }
}