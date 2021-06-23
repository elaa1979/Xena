using System;
using Microsoft.AspNetCore.Http;

namespace Xena.Application.Utils
{
    public class UserHelper
    {
        private readonly HttpContext _context;
        public UserHelper(IHttpContextAccessor contextAccessor)
        {
            _context = contextAccessor.HttpContext;
        }
        public int GetUserId()
        {
            if (int.TryParse(_context.User.Identity.Name, out int id))
                return id;

            throw new UnauthorizedAccessException("User is not authenticated");
        }
    }
}