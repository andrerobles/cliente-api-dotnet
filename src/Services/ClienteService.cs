using ClienteApi.Data.Entities;
using ClienteApi.Data.Repositories;
using ClienteApi.ViewModels;

namespace ClienteApi.Services;
public class ClienteService : IClienteService
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteService(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public IEnumerable<ClienteViewModel> GetAll()
    {
        var clientes = _clienteRepository.GetAll();
        var clientesViewModel = new List<ClienteViewModel>();
        foreach (var cliente in clientes)
        {
            var clienteViewModel = ClienteViewModel.FromCliente(cliente);
            clientesViewModel.Add(clienteViewModel);
        }

        return clientesViewModel;
    }

    public Cliente? GetById(int id)
    {
        return _clienteRepository.GetById(id);
    }

    public void Add(ClienteViewModel clienteViewModel)
    {
        var cliente = new Cliente
        {
            Nome = clienteViewModel.Nome,
            Email = clienteViewModel.Email,
            Telefone = clienteViewModel.Telefone,
            EstaAtivo = string.Equals(clienteViewModel.EstaAtivo, "Sim", StringComparison.OrdinalIgnoreCase),
            Descricao = clienteViewModel.Descricao,
            CreatedAt = DateTime.Now.ToUniversalTime(),  
            UpdatedAt = DateTime.Now.ToUniversalTime()
        };

        _clienteRepository.Add(cliente);
    }

    public void Update(int id, ClienteViewModel clienteViewModel)
    {
        var cliente = new Cliente
        {
            Nome = clienteViewModel.Nome,
            Email = clienteViewModel.Email,
            Telefone = clienteViewModel.Telefone,
            EstaAtivo = string.Equals(clienteViewModel.EstaAtivo, "Sim", StringComparison.OrdinalIgnoreCase),
            Descricao = clienteViewModel.Descricao,
            CreatedAt = DateTime.Now.ToUniversalTime(),  
            UpdatedAt = DateTime.Now.ToUniversalTime()
        };

        _clienteRepository.Update(id, cliente);
    }

    public void Delete(int id)
    {
        _clienteRepository.Delete(id);
    }
}
