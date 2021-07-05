using System;
using System.Collections.Generic;

namespace Xena.Domain.Users
{
    public class User:BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public UserStatus Status { get; set; }
        public List<UserRole> Roles { get; set; }

    }
}