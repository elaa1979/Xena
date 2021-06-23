using System;

namespace Xena.Domain.Users
{
    public class BlackListedToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime LogoutDate { get; set; }
    }
}