using Microsoft.AspNetCore.Mvc;
using ClienteApi.Services;
using ClienteApi.ViewModels;


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
        public IActionResult GetAllUsuarios()
        {
            var usuarios = _usuarioService.GetAll();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
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
        public IActionResult AddUsuario(UsuarioViewModel usuarioViewModel)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(usuarioViewModel.Nome) || 
                    string.IsNullOrWhiteSpace(usuarioViewModel.Email))
                {
                    throw new ArgumentException("Os atributos Nome e Email são campos obrigatórios.");
                }
                _usuarioService.Add(usuarioViewModel);
                return Ok("Usuario adicionado com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao adicionar o usuario: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUsuario(int id, UsuarioViewModel usuarioViewModel)
        {
            try
            {
                var existingUsuario = _usuarioService.GetById(id);
                if (existingUsuario == null)
                {
                    return NotFound($"Usuario com o ID {id} não encontrado");
                }

                if (string.IsNullOrWhiteSpace(usuarioViewModel.Nome) || 
                    string.IsNullOrWhiteSpace(usuarioViewModel.Email))
                {
                    throw new ArgumentException("Os atributos Nome e Email são campos obrigatórios.");
                }

                _usuarioService.Update(id, usuarioViewModel);

                return Ok("Usuario atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao atualizar o usuario: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
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

