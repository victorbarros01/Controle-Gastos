using Microsoft.IdentityModel.Tokens;
using ProjetoAspNet.Data;
using ProjetoAspNet.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjetoAspNet.Service {
    public class TokenService {
        public string Generate(User user) {
            //Cria uma instância do JwtSecurityHandler
            var handler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(Configuration.PrivateKey);
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = GenerateClaims(user),
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(2)
            };

            // Gera um Token
            var token = handler.CreateToken(tokenDescriptor);

            // Gera uma string do Token
            return handler.WriteToken(token);
        }

        public static ClaimsIdentity GenerateClaims(User user) {
            var claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, user.Username));

            return claimsIdentity;
        }
    }
}
