using lista_presentes.DTOs;
using lista_presentes.DTOs.TipoChavePix;
using lista_presentes.Entities;
using lista_presentes.Repositories.Interfaces;
using lista_presentes.Utils;
using Microsoft.EntityFrameworkCore;

namespace lista_presentes.Repositories.Implementations
{
    public class TipoChavePixRepository : ITipoChavePixRepository
    {
        private readonly MyDbContext _dbContext;

        public TipoChavePixRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private TipoChavePixListagemDTO ConvertToDTO(TipoChavePix usuario)
        {
            return new TipoChavePixListagemDTO
            {
                Id = usuario.Id,
                Descricao = usuario.Descricao,

                DataUltimaAlteracao = usuario.DataEdicao != null ? usuario.DataEdicao.Value : usuario.DataCadastro
            };
        }

        public async Task<TipoChavePixListagemDTO> GetTipoChavePixByIdAsync(int id)
        {
            var usuario = await _dbContext.TipoChavePix.FindAsync(id);
            if (usuario == null)
                throw new KeyNotFoundException("Tipo não encontrado!");

            return ConvertToDTO(usuario);
        }

        public async Task<List<TipoChavePixListagemDTO>> GetTipoChavePixListagemAsync(FiltrosPaginacaoDTO filtros)
        {
            var dbQuery = _dbContext.TipoChavePix.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filtros.Pesquisa))
            {
                var pesquisa = "%" + filtros.Pesquisa.ToLower() + "%";
                dbQuery = dbQuery.Where(x => EF.Functions.Like(x.Descricao.ToLower(), pesquisa));
            }

            var lista = await dbQuery
                .OrderByDescending(x => x.Id)
                .Skip(filtros.CurrentPage * filtros.PageSize)
                .Take(filtros.PageSize)
                .ToListAsync();

            return lista.Select(x => ConvertToDTO(x)).ToList();
        }

        private static void ValidaCadastroDTO(TipoChavePixCadastroDTO usuario)
        {
            if (usuario == null)
                throw new Exception("Informe os dados do Tipo");

            if (string.IsNullOrWhiteSpace(usuario.Descricao))
                throw new Exception("Informe 'Descrição' do Tipo!");
        }

        public async Task<int> CreateTipoChavePixAsync(TipoChavePixCadastroDTO usuario)
        {
            ValidaCadastroDTO(usuario);

            var novoTipoChavePix = new TipoChavePix();
            novoTipoChavePix.Descricao = usuario.Descricao;
            novoTipoChavePix.DataCadastro = DateTime.UtcNow;

            await _dbContext.TipoChavePix.AddAsync(novoTipoChavePix);
            await _dbContext.SaveChangesAsync();

            return novoTipoChavePix.Id;
        }

        public async Task<int> UpdateTipoChavePixAsync(TipoChavePixCadastroDTO usuarioDTO, int id)
        {
            ValidaCadastroDTO(usuarioDTO);

            var usuario = await _dbContext.TipoChavePix.FindAsync(id);
            if (usuario == null)
                throw new KeyNotFoundException("Tipo não encontrado!");

            usuario.Descricao = usuarioDTO.Descricao;
            usuario.DataEdicao = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync();
            return usuario.Id;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var usuario = await _dbContext.TipoChavePix.FindAsync(id);
            if (usuario == null)
                throw new KeyNotFoundException("Tipo não encontrado!");

            _dbContext.TipoChavePix.Remove(usuario);
            await _dbContext.SaveChangesAsync();
            return id;
        }
    }
}
