using lista_presentes.DTOs;
using lista_presentes.DTOs.Lista;
using lista_presentes.Entities;
using lista_presentes.Repositories.Interfaces;
using lista_presentes.Utils;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace lista_presentes.Repositories.Implementations
{
    public class ListaRepository : IListaRepository
    {
        private readonly MyDbContext _dbContext;

        public ListaRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private ListaListagemDTO ConvertToDTO(Lista lista)
        {
            return new ListaListagemDTO
            {
                Id = lista.Id,
                Descricao = lista.Descricao,
                Link = lista.Link,
                UsuarioId = lista.UsuarioId,
                Usuario = lista.Usuario != null ? new DTOs.Usuario.UsuarioListagemDTO
                {
                    Id = lista.Usuario.Id,
                    Nome = lista.Usuario.Nome,

                    DataUltimaAlteracao = lista.Usuario.DataEdicao != null ? lista.Usuario.DataEdicao.Value : lista.Usuario.DataCadastro
                } : null,

                DataUltimaAlteracao = lista.DataEdicao != null ? lista.DataEdicao.Value : lista.DataCadastro
            };
        }

        public async Task<ListaListagemDTO> GetListaByIdAsync(int id)
        {
            var lista = await _dbContext.Lista.FindAsync(id);
            if (lista == null)
                throw new KeyNotFoundException("Lista não encontrada!");

            return ConvertToDTO(lista);
        }

        public async Task<List<ListaListagemDTO>> GetListaListagemAsync(ListaFiltrosListagemDTO filtros)
        {
            var dbQuery = _dbContext.Lista.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filtros.Pesquisa))
            {
                var pesquisa = "%" + filtros.Pesquisa.ToLower() + "%";
                dbQuery = dbQuery.Where(x => EF.Functions.Like(x.Descricao.ToLower(), pesquisa) ||
                                             EF.Functions.Like(x.Usuario.Nome.ToLower(), pesquisa));
            }

            if(filtros.UsuarioId != null)
                dbQuery = dbQuery.Where(x => x.UsuarioId == filtros.UsuarioId);

            var lista = await dbQuery
                .OrderByDescending(x => x.Id)
                .Skip(filtros.CurrentPage * filtros.PageSize)
                .Take(filtros.PageSize)
                .ToListAsync();

            return lista.Select(x => ConvertToDTO(x)).ToList();
        }

        private async Task ValidaCadastroDTO(ListaCadastroDTO lista)
        {
            if (lista == null)
                throw new Exception("Informe os dados da Lista");

            if (string.IsNullOrWhiteSpace(lista.Descricao))
                throw new Exception("Informe 'Nome' da Lista!");

            if (lista.UsuarioId == null)
                throw new Exception("Informe o 'Usuário' proprietário da Lista!");
            else
            {
                var usuario = await _dbContext.Usuario.FindAsync(lista.UsuarioId);
                if(usuario == null)
                    throw new KeyNotFoundException("Usuário proprietário não encontrado!");
            }
        }

        public async Task<int> CreateListaAsync(ListaCadastroDTO lista)
        {
            await ValidaCadastroDTO(lista);

            var novaLista = new Lista();
            novaLista.Descricao = lista.Descricao;
            novaLista.UsuarioId = lista.UsuarioId.Value;
            novaLista.DataCadastro = DateTime.UtcNow;

            await _dbContext.Lista.AddAsync(novaLista);
            await _dbContext.SaveChangesAsync();

            var uuidById = Hash.GetUUIDHashCode(novaLista.Id);
            novaLista.Link = $"/lista?proprietario={uuidById}";

            await _dbContext.SaveChangesAsync();
            return novaLista.Id;
        }

        public async Task<int> UpdateListaAsync(ListaCadastroDTO listaDTO, int id)
        {
            await ValidaCadastroDTO(listaDTO);

            var lista = await _dbContext.Lista.FindAsync(id);
            if (lista == null)
                throw new KeyNotFoundException("Lista não encontrada!");

            lista.Descricao = listaDTO.Descricao;
            lista.UsuarioId = listaDTO.UsuarioId.Value;
            lista.DataEdicao = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync();
            return lista.Id;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var lista = await _dbContext.Lista.FindAsync(id);
            if (lista == null)
                throw new KeyNotFoundException("Lista não encontrada!");

            _dbContext.Lista.Remove(lista);
            await _dbContext.SaveChangesAsync();
            return id;
        }
    }
}
