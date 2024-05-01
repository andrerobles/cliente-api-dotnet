using ClienteApi.Data.Entities;
using ClienteApi.ViewModels;

namespace ClienteApi.Services;
public interface IClienteService
{
    IEnumerable<ClienteViewModel> GetAll();
    Cliente? GetById(int id);
    void Add(ClienteViewModel clienteViewModel);
    void Update(int id, ClienteViewModel clienteViewModel);
    void Delete(int id);
}