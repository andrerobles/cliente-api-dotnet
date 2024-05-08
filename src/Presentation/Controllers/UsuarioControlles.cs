using Microsoft.AspNetCore.Mvc;
using ClienteApi.Services;
using ClienteApi.ViewModels;
using Microsoft.AspNetCore.Authorization;


namespace ClienteApi.Web.Controllers;

[Route("api/usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
         private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllUsuarios()
        {
            var usuarios = _usuarioService.GetAll();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetUsuarioById(int id)
        {
            var usuario = _usuarioService.GetById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddUsuario(UsuarioVM usuarioVM)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(usuarioVM.Nome) || 
                    string.IsNullOrWhiteSpace(usuarioVM.Email))
                {
                    throw new ArgumentException("Os atributos Nome e Email são campos obrigatórios.");
                }
                _usuarioService.Add(usuarioVM);
                return Ok("Usuario adicionado com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao adicionar o usuario: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult UpdateUsuario(int id, UsuarioVM usuarioVM)
        {
            try
            {
                var existingUsuario = _usuarioService.GetById(id);
                if (existingUsuario == null)
                {
                    return NotFound($"Usuario com o ID {id} não encontrado");
                }

                if (string.IsNullOrWhiteSpace(usuarioVM.Nome) || 
                    string.IsNullOrWhiteSpace(usuarioVM.Email))
                {
                    throw new ArgumentException("Os atributos Nome e Email são campos obrigatórios.");
                }

                _usuarioService.Update(id, usuarioVM);

                return Ok("Usuario atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao atualizar o usuario: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteUsuario(int id)
        {
            try
            {
                var existingUsuario = _usuarioService.GetById(id);
                if (existingUsuario == null)
                {
                    return NotFound($"Usuario com o ID {id} não encontrado");
                }

                _usuarioService.Delete(id);

                return Ok("Usuario excluído com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao excluir o usuario: {ex.Message}");
            }
        }
    }

