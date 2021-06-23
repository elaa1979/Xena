using System;
using Xena.Application.Common.Models;

namespace Xena.Application.Queries.Users
{
    public class UserDto: BaseDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public string Caption { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
    }
}