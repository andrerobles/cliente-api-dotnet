using ClienteApi.Data.Entities;
using ClienteApi.Data.Repositories;
using ClienteApi.ViewModels;

namespace ClienteApi.Services;
public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public IEnumerable<UsuarioViewModel> GetAll()
    {
        var usuarios = _usuarioRepository.GetAll();
        var usuariosViewModel = new List<UsuarioViewModel>();
        foreach (var usuario in usuarios)
        {
            var usuarioViewModel = UsuarioViewModel.FromUsuario(usuario);
            usuariosViewModel.Add(usuarioViewModel);
        }

        return usuariosViewModel;
    }

    public Usuario? GetById(int id)
    {
        return _usuarioRepository.GetById(id);
    }

    public void Add(UsuarioViewModel usuarioViewModel)
    {
        var usuario = new Usuario
        {
            Nome = usuarioViewModel.Nome,
            Email = usuarioViewModel.Email,
            CreatedAt = DateTime.Now.ToUniversalTime(),  
            UpdatedAt = DateTime.Now.ToUniversalTime()
        };

        _usuarioRepository.Add(usuario);
    }

    public void Update(int id, UsuarioViewModel usuarioViewModel)
    {
        var usuario = new Usuario
        {
            Nome = usuarioViewModel.Nome,
            Email = usuarioViewModel.Email,
            CreatedAt = DateTime.Now.ToUniversalTime(),  
            UpdatedAt = DateTime.Now.ToUniversalTime()
        };

        _usuarioRepository.Update(id, usuario);
    }

    public void Delete(int id)
    {
        _usuarioRepository.Delete(id);
    }
}
