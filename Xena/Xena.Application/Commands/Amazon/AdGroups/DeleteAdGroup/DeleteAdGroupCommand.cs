using MediatR;

namespace Xena.Application.Commands.Amazon.AdGroups.DeleteAdGroup
{
    public class DeleteAdGroupCommand: IRequest
    {
        public long Id { get; set; }
    }
}