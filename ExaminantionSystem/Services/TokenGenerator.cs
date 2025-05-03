using ExaminationSystem.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExaminantionSystem.Services
{
    public class TokenGenerator
    {
        public static string GeneratorToken(string id, string name, string roleID) 
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("ID", id),
                    new Claim("RoleID", roleID),
                    new Claim(ClaimTypes.Name, name)
                }),
                Expires = DateTime.Now.AddHours(1),
                Issuer = "UpSkilling",
                Audience = "UpSkilling-Users",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Constants.Secretkey)), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
