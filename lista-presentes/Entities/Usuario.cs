using System.ComponentModel.DataAnnotations.Schema;

namespace lista_presentes.Entities
{
    [Table("usuario")]
    public class Usuario : BaseEntity
    {
        [Column("nome")]
        public string Nome { get; set; } = string.Empty;
    }
}
