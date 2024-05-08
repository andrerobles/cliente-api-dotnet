using ClienteApi.Data.Entities;

namespace ClienteApi.ViewModels

{
    public class UsuarioVM
    {
        public int id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? CreatedAt { get; set; }   
        public string? UpdatedAt { get; set; }
        
        private static string? ConvertDateTimeFormat(DateTime? dateTime)
        {
            if (dateTime.HasValue) {
                return dateTime.Value.ToString("dd/MM/yyyy HH:mm:ss");
            }
            return null;
        }

        public static UsuarioVM FromUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }

            return new UsuarioVM
            {
                id = usuario.id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                CreatedAt = ConvertDateTimeFormat(usuario.CreatedAt),
                UpdatedAt = ConvertDateTimeFormat(usuario.UpdatedAt) 
            };
        }
    }
}
