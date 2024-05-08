using ClienteApi.Data.Entities;
using ClienteApi.ViewModels;

namespace ClienteApi.Services;
public interface IClienteService
{
    IEnumerable<ClienteVM> GetAll();
    Cliente? GetById(int id);
    void Add(ClienteVM clienteVM);
    void Update(int id, ClienteVM clienteVM);
    void Delete(int id);
}