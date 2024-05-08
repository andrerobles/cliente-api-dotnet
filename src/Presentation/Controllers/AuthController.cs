using Microsoft.AspNetCore.Mvc;
using ClienteApi.Services;
using ClienteApi.ViewModels;

namespace ClienteApi.Web.Controllers;

[Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
          _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Selecionar(UserViewModel userViewModel) {
          //Verifica se usuário existe
          var userExist = await _authService.UserExists(userViewModel.Email);
          if(!userExist)
          {
            return Unauthorized("Usuário ou senha inválido.");
          }
          //Verifica se usuário e senha estão validos para dar continuidade no processo
          var authUser = await _authService.AuthenticateAsync(userViewModel.Email, userViewModel.Senha);
          if(!authUser)
          {
            return Unauthorized("Usuário ou senha inválido.");
          }

          var user = await _authService.GetUserByEmail(userViewModel.Email);
          var token = _authService.GenerateToken(user);

          return token;
        }
    }

