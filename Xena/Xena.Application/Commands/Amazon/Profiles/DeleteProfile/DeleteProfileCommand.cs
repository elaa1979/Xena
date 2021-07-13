using MediatR;

namespace Xena.Application.Commands.Amazon.Profiles.DeleteProfile
{
    public class DeleteProfileCommand: IRequest
    {
        public long Id { get; set; }
    }
}