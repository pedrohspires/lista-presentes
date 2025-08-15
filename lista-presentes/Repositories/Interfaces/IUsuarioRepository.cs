using lista_presentes.DTOs;
using lista_presentes.DTOs.Usuario;

namespace lista_presentes.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        public Task<UsuarioListagemDTO> GetUsuarioByIdAsync(int id);
        public Task<List<UsuarioListagemDTO>> GetUsuarioListagemAsync(FiltrosPaginacaoDTO filtros);
        public Task<int> CreateUsuarioAsync(UsuarioCadastroDTO usuario);
        public Task<int> UpdateUsuarioAsync(UsuarioCadastroDTO usuarioDTO, int id);
        public Task<int> DeleteAsync(int id);
    }
}
