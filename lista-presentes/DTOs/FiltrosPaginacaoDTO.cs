namespace lista_presentes.DTOs
{
    public class FiltrosPaginacaoDTO
    {
        public string? Pesquisa { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
