using System.ComponentModel.DataAnnotations.Schema;

namespace lista_presentes.Entities
{
    [Table("tipo_chave_pix")]
    public class TipoChavePix: BaseEntity
    {
        [Column("descricao")]
        public string Descricao { get; set; } = string.Empty;
    }
}
