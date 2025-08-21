using lista_presentes.DTOs.TipoChavePix;
using lista_presentes.DTOs.Usuario;
using lista_presentes.Entities;

namespace lista_presentes.DTOs.Lista
{
    public class ListaListagemDTO : BaseDTO
    {
        public string? Descricao { get; set; }
        public string? UUID { get; set; }
        public int? UsuarioId { get; set; }
        public UsuarioListagemDTO? Usuario { get; set; }
        public double? ValorPix { get; set; }
        public string? ChavePix { get; set; } = string.Empty;
        public int? TipoChavePixId { get; set; }
        public TipoChavePixListagemDTO? TipoChavePix { get; set; }
    }
}
