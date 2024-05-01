using System.ComponentModel.DataAnnotations.Schema;

namespace ClienteApi.Data.Entities
{
    [Table("customers")]
    public class Cliente
    {
        public int id { get; set; }
        [Column("name")]
        public string? Nome { get; set; }
        [Column("email")]
        public string? Email { get; set; }
        [Column("phone")]
        public string? Telefone { get; set; }
        [Column("active")]
        public bool? EstaAtivo { get; set; }
        [Column("description")]
        public string? Descricao { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }   // Alterado para DateTime
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }   // Alterado para DateTime
    }
}
