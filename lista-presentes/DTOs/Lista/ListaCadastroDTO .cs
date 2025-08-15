using lista_presentes.DTOs.Usuario;
using System.ComponentModel.DataAnnotations.Schema;

namespace lista_presentes.DTOs.Lista
{
    public class ListaCadastroDTO
    {
        public string? Descricao { get; set; }
        public int? UsuarioId { get; set; }
    }
}
