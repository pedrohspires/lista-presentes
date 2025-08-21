using lista_presentes.DTOs.Usuario;
using lista_presentes.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace lista_presentes.DTOs.Lista
{
    public class ListaCadastroDTO
    {
        public string? Descricao { get; set; }
        public int? UsuarioId { get; set; }
        public double? ValorPix { get; set; }
        public string? ChavePix { get; set; }
        public int? TipoChavePixId { get; set; }
    }
}
