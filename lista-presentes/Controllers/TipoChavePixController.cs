using lista_presentes.DTOs;
using lista_presentes.DTOs.TipoChavePix;
using lista_presentes.Entities;
using lista_presentes.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lista_presentes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoChavePixController : ControllerBase
    {
        private readonly ITipoChavePixRepository _tipoChavePixRepository;

        public TipoChavePixController(ITipoChavePixRepository tipoChavePixRepository)
        {
            _tipoChavePixRepository = tipoChavePixRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoChavePixListagemDTO>> GetById(int id)
        {
            try
            {
                var result = await _tipoChavePixRepository.GetTipoChavePixByIdAsync(id);
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
        public async Task<ActionResult<List<TipoChavePixListagemDTO>>> GetListagem([FromBody] FiltrosPaginacaoDTO filtros)
        {
            try
            {
                var result = await _tipoChavePixRepository.GetTipoChavePixListagemAsync(filtros);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] TipoChavePixCadastroDTO tipoChavePix)
        {
            try
            {
                var result = await _tipoChavePixRepository.CreateTipoChavePixAsync(tipoChavePix);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Update([FromBody] TipoChavePixCadastroDTO tipoChavePix, int id)
        {
            try
            {
                var result = await _tipoChavePixRepository.UpdateTipoChavePixAsync(tipoChavePix, id);
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
                var result = await _tipoChavePixRepository.DeleteAsync(id);
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
