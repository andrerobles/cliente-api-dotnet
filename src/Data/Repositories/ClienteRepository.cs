using ClienteApi.Data.Entities;

namespace ClienteApi.Data.Repositories;

public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _context.Clientes.ToList();
        }

        public Cliente? GetById(int id)
        {
            return _context.Clientes.FirstOrDefault(c => c.id == id);
        }

        public void Add(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente));
            }

            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void Update(int id, Cliente cliente)
        {
            var existingCliente = _context.Clientes.FirstOrDefault(c => c.id == id);
            if (existingCliente == null)
            {
                throw new ArgumentException($"Cliente com o ID {id} não encontrado");
            }

            existingCliente.Nome = cliente.Nome;
            existingCliente.Email = cliente.Email;
            existingCliente.Telefone = cliente.Telefone;
            existingCliente.EstaAtivo = cliente.EstaAtivo;
            existingCliente.Descricao = cliente.Descricao;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.id == id);
            if (cliente == null)
            {
                throw new ArgumentException($"Cliente com o ID {id} não encontrado");
            }

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }
    }
