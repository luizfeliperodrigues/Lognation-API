using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Lognation.Infra.CrossCutting.Security
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly JwtSettings _jwtSettings;

        public TokenGenerator(JwtSettings jwtSettings)
        {
            this._jwtSettings = jwtSettings;
        }

        public async Task<string> GenerateTokenAsync(int userId, string userEmail)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(JwtRegisteredClaimNames.Email, userEmail));
            claims.Add(new Claim(JwtRegisteredClaimNames.AuthTime, DateTime.UtcNow.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()));

            ClaimsIdentity identity = new ClaimsIdentity(new GenericIdentity(userId.ToString(), "login"), claims);

            // Signing credentials
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._jwtSettings.Secret));

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor()
            {
                Subject = identity,
                SigningCredentials = signingCredentials
            });

            string token = handler.WriteToken(securityToken);

            return await Task.FromResult(token);
        }

        public Task<string> GetUserEmailFromTokenAsync(string rawToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> IsValidTokenAsync(string token)
        {
            throw new System.NotImplementedException();
        }
    }
}
