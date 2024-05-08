using ClienteApi.Data.Entities;

namespace ClienteApi.Data.Repositories;

public class UsuarioRepositoy : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepositoy(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario? GetById(int id)
        {
            return _context.Usuarios.FirstOrDefault(c => c.id == id);
        }

        public Usuario? GetByEmail(string Email)
        {
            return _context.Usuarios.FirstOrDefault(c => c.Email == Email);
        }

        public Usuario? ChecksValidAccess(string Email, string Senha)
        {
            return _context.Usuarios.FirstOrDefault(c => c.Email == Email && c.Senha == Senha);
        }

        public void Add(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Update(int id, Usuario usuario)
        {
            var existingUsuario = _context.Usuarios.FirstOrDefault(c => c.id == id);
            if (existingUsuario == null)
            {
                throw new ArgumentException($"Usuario com o ID {id} não encontrado");
            }

            existingUsuario.Nome = usuario.Nome;
            existingUsuario.Email = usuario.Email;
            existingUsuario.Senha = usuario.Senha;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(c => c.id == id);
            if (usuario == null)
            {
                throw new ArgumentException($"Usuario com o ID {id} não encontrado");
            }

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }
    }
