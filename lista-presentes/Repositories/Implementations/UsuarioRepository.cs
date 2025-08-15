using lista_presentes.DTOs;
using lista_presentes.DTOs.Usuario;
using lista_presentes.Entities;
using lista_presentes.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lista_presentes.Repositories.Implementations
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MyDbContext _dbContext;

        public UsuarioRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private UsuarioListagemDTO ConvertToDTO(Usuario usuario)
        {
            return new UsuarioListagemDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,

                DataUltimaAlteracao = usuario.DataEdicao != null ? usuario.DataEdicao.Value : usuario.DataCadastro
            };
        }

        public async Task<UsuarioListagemDTO> GetUsuarioByIdAsync(int id)
        {
            var usuario = await _dbContext.Usuario.FindAsync(id);
            if (usuario == null)
                throw new KeyNotFoundException("Usuário não encontrado!");

            return ConvertToDTO(usuario);
        }

        public async Task<List<UsuarioListagemDTO>> GetUsuarioListagemAsync(FiltrosPaginacaoDTO filtros)
        {
            var dbQuery = _dbContext.Usuario.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filtros.Pesquisa))
            {
                var pesquisa = "%" + filtros.Pesquisa.ToLower() + "%";
                dbQuery = dbQuery.Where(x => EF.Functions.Like(x.Nome.ToLower(), pesquisa));
            }

            var lista = await dbQuery
                .OrderByDescending(x => x.Id)
                .Skip(filtros.CurrentPage * filtros.PageSize)
                .Take(filtros.PageSize)
                .ToListAsync();

            return lista.Select(x => ConvertToDTO(x)).ToList();
        }

        private static void ValidaCadastroDTO(UsuarioCadastroDTO usuario)
        {
            if (usuario == null)
                throw new Exception("Informe os dados do Usuário");

            if (string.IsNullOrWhiteSpace(usuario.Nome))
                throw new Exception("Informe 'Nome' do Usuário!");
        }

        public async Task<int> CreateUsuarioAsync(UsuarioCadastroDTO usuario)
        {
            ValidaCadastroDTO(usuario);

            var novoUsuario = new Usuario();
            novoUsuario.Nome = usuario.Nome;
            novoUsuario.DataCadastro = DateTime.UtcNow;

            await _dbContext.Usuario.AddAsync(novoUsuario);
            await _dbContext.SaveChangesAsync();

            return novoUsuario.Id;
        }

        public async Task<int> UpdateUsuarioAsync(UsuarioCadastroDTO usuarioDTO, int id)
        {
            ValidaCadastroDTO(usuarioDTO);

            var usuario = await _dbContext.Usuario.FindAsync(id);
            if (usuario == null)
                throw new KeyNotFoundException("Usuário não encontrado!");

            usuario.Nome = usuarioDTO.Nome;
            usuario.DataEdicao = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync();
            return usuario.Id;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var usuario = await _dbContext.Usuario.FindAsync(id);
            if (usuario == null)
                throw new KeyNotFoundException("Usuário não encontrado!");

            _dbContext.Usuario.Remove(usuario);
            await _dbContext.SaveChangesAsync();
            return id;
        }
    }
}
