using MediatR;
using System.Collections.Generic;

namespace Xena.Application.Queries.AmazonServices.GetKeywords
{
    public class GetKeywordsServiceQuery : IRequest<List<KeywordDto>>
    {
        public long ProfileId { get; set; }
        public bool SyncDB { get; set; }
    }
}