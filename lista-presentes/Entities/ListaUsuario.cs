using System.ComponentModel.DataAnnotations.Schema;

namespace lista_presentes.Entities
{
    [Table("lista_usuario")]
    public class ListaUsuario:BaseEntity
    {
        [Column("id_lista")]
        public int ListaId { get; set; }
        public Lista? Lista { get; set; }

        [Column("id_usuario")]
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
