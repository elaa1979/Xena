using MediatR;

namespace Xena.Application.Queries.Users.GetUser
{
    public class GetUserQuery:IRequest<UserDto>
    {
        public int Id { get; set; }
    }
}