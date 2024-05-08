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

    public IEnumerable<ClienteVM> GetAll()
    {
        var clientes = _clienteRepository.GetAll();
        var clientesViewModel = new List<ClienteVM>();
        foreach (var cliente in clientes)
        {
            var clienteViewModel = ClienteVM.FromCliente(cliente);
            clientesViewModel.Add(clienteViewModel);
        }

        return clientesViewModel;
    }

    public Cliente? GetById(int id)
    {
        return _clienteRepository.GetById(id);
    }

    public void Add(ClienteVM clienteVM)
    {
        var cliente = new Cliente
        {
            Nome = clienteVM.Nome,
            Email = clienteVM.Email,
            Telefone = clienteVM.Telefone,
            EstaAtivo = string.Equals(clienteVM.EstaAtivo, "Sim", StringComparison.OrdinalIgnoreCase),
            Descricao = clienteVM.Descricao,
            CreatedAt = DateTime.Now.ToUniversalTime(),  
            UpdatedAt = DateTime.Now.ToUniversalTime()
        };

        _clienteRepository.Add(cliente);
    }

    public void Update(int id, ClienteVM clienteVM)
    {
        var cliente = new Cliente
        {
            Nome = clienteVM.Nome,
            Email = clienteVM.Email,
            Telefone = clienteVM.Telefone,
            EstaAtivo = string.Equals(clienteVM.EstaAtivo, "Sim", StringComparison.OrdinalIgnoreCase),
            Descricao = clienteVM.Descricao,
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
