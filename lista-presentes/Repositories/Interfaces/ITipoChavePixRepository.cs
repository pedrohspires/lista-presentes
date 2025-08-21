using lista_presentes.DTOs;
using lista_presentes.DTOs.TipoChavePix;

namespace lista_presentes.Repositories.Interfaces
{
    public interface ITipoChavePixRepository
    {
        public Task<TipoChavePixListagemDTO> GetTipoChavePixByIdAsync(int id);
        public Task<List<TipoChavePixListagemDTO>> GetTipoChavePixListagemAsync(FiltrosPaginacaoDTO filtros);
        public Task<int> CreateTipoChavePixAsync(TipoChavePixCadastroDTO usuario);
        public Task<int> UpdateTipoChavePixAsync(TipoChavePixCadastroDTO usuarioDTO, int id);
        public Task<int> DeleteAsync(int id);
    }
}
