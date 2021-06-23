using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xena.Application.Abstractions.Repositories;
using Xena.Domain.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Xena.Application.Utils
{
    public class TokenService
    {
        private readonly IConfiguration _config;
        private readonly IUnitOfWork _uow;
        private readonly HttpContext _context;
        public TokenService(IConfiguration config, IUnitOfWork uow, IHttpContextAccessor contextAccessor)
        {
            _config = config;
            _uow = uow;
            _context = contextAccessor.HttpContext;
        }
        public Token CreateToken(int userId)
        {
            var keyBytes = Encoding.ASCII.GetBytes(_config.GetSection("Jwt:Key").Value);
            var tokenHandler = new JwtSecurityTokenHandler();
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(_config.GetSection("Jwt:ExpireMinutes").Get<int>()),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(descriptor);
            return new Token { AccessToken = tokenHandler.WriteToken(token) };
        }

        public async Task<bool> IsBlackListed(string token)
        {
            var blackListedToken = await _uow.GetReposiotory<BlackListedToken>().GetByAsync(x => x.Token == token);
            return blackListedToken != null;
        }

        public async Task AddToBlackList()
        {
            var token = _context.Request.Headers["Authorization"].ToString().Split(" ").Last();
            var blackListedToken = new BlackListedToken
            {
                Token = token,
                LogoutDate = DateTime.Now
            };
            await _uow.GetReposiotory<BlackListedToken>().AddAsync(blackListedToken);
            await _uow.CompleteAsync();
        }
    }
}