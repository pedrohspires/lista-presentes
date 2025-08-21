using System.ComponentModel.DataAnnotations.Schema;

namespace lista_presentes.Entities
{
    [Table("lista")]
    public class Lista : BaseEntity
    {
        [Column("descricao")]
        public string Descricao { get; set; } = string.Empty;

        [Column("id_usuario")]
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        [Column("valor_pix")]
        public double ValorPix { get; set; }

        [Column("chave_pix")]
        public string ChavePix { get; set; } = string.Empty;

        [Column("id_tipo_chave_pix")]
        public int? TipoChavePixId { get; set; }
        public TipoChavePix? TipoChavePix { get; set; }
    }
}
