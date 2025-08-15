using lista_presentes.DTOs.Usuario;

namespace lista_presentes.DTOs.Lista
{
    public class ListaListagemDTO : BaseDTO
    {
        public string? Descricao { get; set; }
        public string? Link { get; set; }
        public int? UsuarioId { get; set; }
        public UsuarioListagemDTO? Usuario { get; set; }
    }
}
