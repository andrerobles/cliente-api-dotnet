using System.Threading.Tasks;
using ClienteApi.ViewModels;

namespace ClienteApi.Services;
public interface IAuthService
{
   Task<bool> AuthenticateAsync(string Email, string Senha);
   Task<bool> UserExists(string email);
   public string GenerateToken(UserViewModel userViewModel);
   public Task<UserViewModel> GetUserByEmail(string email);
}