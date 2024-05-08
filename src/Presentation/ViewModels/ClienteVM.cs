using ClienteApi.Data.Entities;

namespace ClienteApi.ViewModels

{
    public class ClienteVM
    {
        public int id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? EstaAtivo { get; set; }
        public string? Descricao { get; set; }
        public string? CreatedAt { get; set; }   
        public string? UpdatedAt { get; set; }
        
        private static string? ConvertDateTimeFormat(DateTime? dateTime)
        {
            if (dateTime.HasValue) {
                return dateTime.Value.ToString("dd/MM/yyyy HH:mm:ss");
            }
            return null;
        }

        public static ClienteVM FromCliente(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente));
            }

            return new ClienteVM
            {
                id = cliente.id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Telefone = cliente.Telefone,
                EstaAtivo = cliente.EstaAtivo.HasValue && cliente.EstaAtivo.Value ? "Sim" : "Não",
                Descricao = cliente.Descricao,
                CreatedAt = ConvertDateTimeFormat(cliente.CreatedAt),
                UpdatedAt = ConvertDateTimeFormat(cliente.UpdatedAt) 
            };
        }
    }
}
