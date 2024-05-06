using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ClienteApi.ViewModels;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace ClienteApi.Services;
public class AuthService : IAuthService
{
  private readonly IConfiguration _configuration;

  public AuthService(IConfiguration configuration)
  {
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
  }

  public async Task<bool> AuthenticateAsync(string email, string senha)
  {
    //TODO: Implementar verificação de senha
    return true;
  }

  public async Task<bool> UserExists(string email) 
  {
    return true;
  }

  public async Task<UserViewModel> GetUserByEmail(string email)
  {
    if (email == "andrerobles@gmail.com")
    {
            var user = new UserViewModel
            {
                Email = "andrerobles@gmail.com",
                Id = 1
            };
            return user;
    }

    throw new ArgumentException("Usuário não encontrado", nameof(email));
  }

  public string GenerateToken(UserViewModel userViewModel)
  {
    var claims = new[]
    {
      new Claim("id", userViewModel.Id.ToString()),
      new Claim("email", userViewModel.Email),
      new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

    var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:secretKey"]));
    var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);
    var expiration = DateTime.UtcNow.AddMinutes(10);

    JwtSecurityToken token = new JwtSecurityToken(
      issuer: _configuration["jwt:issuer"],
      audience: _configuration["jwt:audience"],
      claims: claims,
      expires: expiration,
      signingCredentials: credentials
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
  }
}
