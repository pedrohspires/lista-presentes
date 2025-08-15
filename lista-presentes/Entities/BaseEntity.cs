using System.ComponentModel.DataAnnotations.Schema;

namespace lista_presentes.Entities
{
    public class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("data_cadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("data_edicao")]
        public DateTime? DataEdicao{ get; set; }
    }
}
