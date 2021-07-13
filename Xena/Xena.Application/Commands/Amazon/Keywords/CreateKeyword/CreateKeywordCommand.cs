using System;
using MediatR;

namespace Xena.Application.Commands.Amazon.Keywords.CreateKeyword
{
    public class CreateKeywordCommand : IRequest
    {
        public long keywordId { get; set; }
        public long profileId { get; set; }
        public long adGroupId { get; set; }
        public long campaignId { get; set; }
        public string keywordText { get; set; }
        public string matchType { get; set; }
        public string state { get; set; }
        public double bid { get; set; }
    }
}