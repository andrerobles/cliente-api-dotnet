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

    public IEnumerable<UsuarioVM> GetAll()
    {
        var usuarios = _usuarioRepository.GetAll();
        var usuariosViewModel = new List<UsuarioVM>();
        foreach (var usuario in usuarios)
        {
            var usuarioVM = UsuarioVM.FromUsuario(usuario);
            usuariosViewModel.Add(usuarioVM);
        }

        return usuariosViewModel;
    }

    public Usuario? GetById(int id)
    {
        return _usuarioRepository.GetById(id);
    }

    public Usuario? ChecksValidAccess(string Email, string Senha)
    {
        return _usuarioRepository.ChecksValidAccess(Email, Senha);
    }

    public Usuario? GetByEmail(string Email)
    {
        return _usuarioRepository.GetByEmail(Email);
    }

    public void Add(UsuarioVM usuarioVM)
    {
        var usuario = new Usuario
        {
            Nome = usuarioVM.Nome,
            Email = usuarioVM.Email,
            CreatedAt = DateTime.Now.ToUniversalTime(),  
            UpdatedAt = DateTime.Now.ToUniversalTime()
        };

        _usuarioRepository.Add(usuario);
    }

    public void Update(int id, UsuarioVM usuarioVM)
    {
        var usuario = new Usuario
        {
            Nome = usuarioVM.Nome,
            Email = usuarioVM.Email,
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
