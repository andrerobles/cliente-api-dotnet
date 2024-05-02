using System.ComponentModel.DataAnnotations.Schema;

namespace ClienteApi.Data.Entities
{
    [Table("users")]
    public class Usuario
    {
        public int id { get; set; }
        [Column("name")]
        public string? Nome { get; set; }
        [Column("email")]
        public string? Email { get; set; }
        [Column("password")]
        public string? Senha { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }   // Alterado para DateTime
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }   // Alterado para DateTime
    }
}
