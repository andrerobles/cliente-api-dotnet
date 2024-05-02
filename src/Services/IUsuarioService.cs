using ClienteApi.Data.Entities;
using ClienteApi.ViewModels;

namespace ClienteApi.Services;
public interface IUsuarioService
{
    IEnumerable<UsuarioViewModel> GetAll();
    Usuario? GetById(int id);
    void Add(UsuarioViewModel usuarioViewModel);
    void Update(int id, UsuarioViewModel usuarioViewModel);
    void Delete(int id);
}