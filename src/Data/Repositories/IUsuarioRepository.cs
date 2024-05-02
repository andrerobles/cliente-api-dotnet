using ClienteApi.Data.Entities;

namespace ClienteApi.Data.Repositories;

public interface IUsuarioRepository
    {
        IEnumerable<Usuario> GetAll();
        Usuario? GetById(int id);
        void Add(Usuario usuario);
        void Update(int id, Usuario usuario);
        void Delete(int id);
    }