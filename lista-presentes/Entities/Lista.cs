using System.ComponentModel.DataAnnotations.Schema;

namespace lista_presentes.Entities
{
    [Table("lista")]
    public class Lista : BaseEntity
    {
        [Column("descricao")]
        public string Descricao { get; set; } = string.Empty;
    }
}
