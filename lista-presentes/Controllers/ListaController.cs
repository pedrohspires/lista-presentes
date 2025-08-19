using lista_presentes.DTOs;
using lista_presentes.DTOs.Lista;
using lista_presentes.DTOs.Usuario;
using lista_presentes.Entities;
using lista_presentes.Repositories.Implementations;
using lista_presentes.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lista_presentes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaController : ControllerBase
    {
        private readonly IListaRepository _listaRepository;

        public ListaController(IListaRepository listaRepository)
        {
            _listaRepository = listaRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ListaListagemDTO>> GetById(int id)
        {
            try
            {
                var result = await _listaRepository.GetListaByIdAsync(id);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Listagem")]
        public async Task<ActionResult<List<ListaListagemDTO>>> GetListagem([FromBody] ListaFiltrosListagemDTO filtros)
        {
            try
            {
                var result = await _listaRepository.GetListaListagemAsync(filtros);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] ListaCadastroDTO lista)
        {
            try
            {
                var result = await _listaRepository.CreateListaAsync(lista);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Update([FromBody] ListaCadastroDTO lista, int id)
        {
            try
            {
                var result = await _listaRepository.UpdateListaAsync(lista, id);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            try
            {
                var result = await _listaRepository.DeleteAsync(id);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ByUUID/{uuid}")]
        public async Task<ActionResult<ListaListagemDTO>> GetByUUID(string uuid)
        {
            try
            {
                var result = await _listaRepository.GetListaByUUIDAsync(uuid);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
