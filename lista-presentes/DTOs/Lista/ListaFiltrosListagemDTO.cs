using lista_presentes.DTOs.Usuario;

namespace lista_presentes.DTOs.Lista
{
    public class ListaFiltrosListagemDTO : FiltrosPaginacaoDTO
    {
        public int? UsuarioId { get; set; }
    }
}
