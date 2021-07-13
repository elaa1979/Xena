using MediatR;
using System.Collections.Generic;

namespace Xena.Application.Queries.Amazon.Keywords.GetKeyword
{
    public class GetKeywordQuery : IRequest<KeywordDto>
    {
        public long Id { get; set; }
    }
}