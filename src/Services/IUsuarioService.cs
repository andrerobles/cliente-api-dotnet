using ClienteApi.Data.Entities;
using ClienteApi.ViewModels;

namespace ClienteApi.Services;
public interface IUsuarioService
{
    IEnumerable<UsuarioVM> GetAll();
    Usuario? GetById(int id);
    Usuario? GetByEmail(string Email);
    Usuario? ChecksValidAccess(string Email, string Senha);
    void Add(UsuarioVM usuarioVM);
    void Update(int id, UsuarioVM usuarioVM);
    void Delete(int id);
}