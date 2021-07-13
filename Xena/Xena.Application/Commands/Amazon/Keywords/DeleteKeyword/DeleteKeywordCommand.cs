using MediatR;

namespace Xena.Application.Commands.Amazon.Keywords.DeleteKeyword
{
    public class DeleteKeywordCommand: IRequest
    {
        public long Id { get; set; }
    }
}