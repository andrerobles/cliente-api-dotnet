using System.Threading.Tasks;
using ClienteApi.ViewModels;

namespace ClienteApi.Services;
public interface IAuthService
{
   Task<bool> AuthenticateAsync(string Email, string Senha);
   Task<bool> UserExists(string email);
   public string GenerateToken(AuthVM authVM);
   public Task<AuthVM> GetUserByEmail(string email);
}