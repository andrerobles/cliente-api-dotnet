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
        public async Task<ActionResult<TokenVM>> Selecionar(AuthVM authVM) {
          //Verifica se usuário existe
          var userExist = await _authService.UserExists(authVM.Email);
          if(!userExist)
          {
            return Unauthorized("Usuário ou senha inválido.");
          }
          //Verifica se usuário e senha estão validos para dar continuidade no processo
          var authUser = await _authService.AuthenticateAsync(authVM.Email, authVM.Senha);
          if(!authUser)
          {
            return Unauthorized("Usuário ou senha inválido.");
          }

          var user = await _authService.GetUserByEmail(authVM.Email);
          var token = _authService.GenerateToken(user);

          return new TokenVM 
          {
            Token = token
          };
        }
    }

