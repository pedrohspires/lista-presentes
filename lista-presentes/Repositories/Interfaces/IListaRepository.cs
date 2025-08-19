using lista_presentes.DTOs;
using lista_presentes.DTOs.Lista;
using lista_presentes.DTOs.Usuario;

namespace lista_presentes.Repositories.Interfaces
{
    public interface IListaRepository
    {
        public Task<ListaListagemDTO> GetListaByIdAsync(int id);
        public Task<List<ListaListagemDTO>> GetListaListagemAsync(ListaFiltrosListagemDTO filtros);
        public Task<int> CreateListaAsync(ListaCadastroDTO usuario);
        public Task<int> UpdateListaAsync(ListaCadastroDTO usuarioDTO, int id);
        public Task<int> DeleteAsync(int id);
        public Task<ListaListagemDTO> GetListaByUUIDAsync(string uuid);
    }
}
