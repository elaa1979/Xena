using MediatR;
using System.Collections.Generic;

namespace Xena.Application.Queries.AmazonServices.GetKeywords
{
    public class GetKeywordsQuery : IRequest<List<KeywordDto>>
    {
        public long ProfileId { get; set; }
    }
}