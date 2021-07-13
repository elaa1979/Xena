using MediatR;
using System.Collections.Generic;

namespace Xena.Application.Queries.Amazon.Keywords.GetKeywords
{
    public class GetKeywordsQuery : IRequest<List<KeywordDto>>
    {
        public long ProfileId { get; set; }
        public bool Nocache { get; set; }
    }
}