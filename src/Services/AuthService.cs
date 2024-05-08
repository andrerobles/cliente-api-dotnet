using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ClienteApi.ViewModels;
using Microsoft.IdentityModel.Tokens;

namespace ClienteApi.Services;
public class AuthService : IAuthService
{
  private readonly IConfiguration _configuration;
  private readonly IUsuarioService _usuarioService;

  public AuthService(IConfiguration configuration, IUsuarioService usuarioService)
  {
    _configuration = configuration;
    _usuarioService = usuarioService;

  }

  public async Task<bool> AuthenticateAsync(string Email, string Senha)
  {
    var user = _usuarioService.ChecksValidAccess(Email, Senha);
    if(user == null) 
    {
      return false;
    }
    return true;
  }

  public async Task<bool> UserExists(string Email) 
  {
    var user = _usuarioService.GetByEmail(Email);
    if (user == null)
    {
      return false;
    }

    return true;
  }

  public async Task<AuthVM> GetUserByEmail(string Email)
  {

    var user = _usuarioService.GetByEmail(Email);

    if (user != null)
    {
            var authVM = new AuthVM
            {
                Email = user.Email,
                Id = user.id
            };
            return authVM;
    }

    throw new ArgumentException("Usuário não encontrado", nameof(Email));
  }

  public string GenerateToken(AuthVM authVM)
  {
    var claims = new[]
    {
      new Claim("id", authVM.Id.ToString()),
      new Claim("email", authVM.Email),
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
