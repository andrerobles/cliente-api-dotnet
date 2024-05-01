using ClienteApi.Data.Entities;

namespace ClienteApi.Data.Repositories;

public interface IClienteRepository
    {
        IEnumerable<Cliente> GetAll();
        Cliente? GetById(int id);
        void Add(Cliente cliente);
        void Update(int id, Cliente cliente);
        void Delete(int id);
    }