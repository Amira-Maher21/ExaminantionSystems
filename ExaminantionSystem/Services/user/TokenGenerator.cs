using ExaminantionSystem.DTOS;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExaminantionSystem.Services.user
{
    
        public class TokenGenerator
        {
            public static string GenerateToken(TokenDto tokenDto, IConfiguration config)
            {
                var key = Encoding.UTF8.GetBytes(config["JWT:SecretKey"]);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.NameIdentifier, tokenDto.UsersID.ToString()),
                    new Claim(ClaimTypes.Name, tokenDto.Name),
                    new Claim(ClaimTypes.Role, tokenDto.AuthorizeRoleName),


                     

                }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    Issuer = config["JWT:Issuer"],
                    Audience = config["JWT:Audience"],
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);
            }
        }
    
}
