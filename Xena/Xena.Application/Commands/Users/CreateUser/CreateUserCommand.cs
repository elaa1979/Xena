using System;
using MediatR;

namespace Xena.Application.Commands.Users.Register
{
    public class CreateUserCommand :IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Photo { get; set; }
        public string Caption { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}