using Microsoft.AspNetCore.Mvc;
using ClienteApi.Services;
using ClienteApi.ViewModels;


namespace ClienteApi.Web.Controllers;

[Route("api/clientes")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
         private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public IActionResult GetAllClientes()
        {
            var clientes = _clienteService.GetAll();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public IActionResult GetClienteById(int id)
        {
            var cliente = _clienteService.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult AddCliente(ClienteViewModel clienteViewModel)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(clienteViewModel.Nome) || 
                    string.IsNullOrWhiteSpace(clienteViewModel.Email) || 
                    string.IsNullOrWhiteSpace(clienteViewModel.Telefone) || 
                    string.IsNullOrWhiteSpace(clienteViewModel.EstaAtivo))
                {
                    throw new ArgumentException("Os atributos Nome, Email, Telefone e EstaAtivo são campos obrigatórios.");
                }
                _clienteService.Add(clienteViewModel);
                return Ok("Cliente adicionado com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao adicionar o cliente: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCliente(int id, ClienteViewModel clienteViewModel)
        {
            try
            {
                var existingCliente = _clienteService.GetById(id);
                if (existingCliente == null)
                {
                    return NotFound($"Cliente com o ID {id} não encontrado");
                }

                if (string.IsNullOrWhiteSpace(clienteViewModel.Nome) || 
                    string.IsNullOrWhiteSpace(clienteViewModel.Email) || 
                    string.IsNullOrWhiteSpace(clienteViewModel.Telefone) || 
                    string.IsNullOrWhiteSpace(clienteViewModel.EstaAtivo))
                {
                    throw new ArgumentException("Os atributos Nome, Email, Telefone e EstaAtivo são campos obrigatórios.");
                }

                _clienteService.Update(id, clienteViewModel);

                return Ok("Cliente atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao atualizar o cliente: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            try
            {
                var existingCliente = _clienteService.GetById(id);
                if (existingCliente == null)
                {
                    return NotFound($"Cliente com o ID {id} não encontrado");
                }

                _clienteService.Delete(id);

                return Ok("Cliente excluído com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao excluir o cliente: {ex.Message}");
            }
        }
    }

