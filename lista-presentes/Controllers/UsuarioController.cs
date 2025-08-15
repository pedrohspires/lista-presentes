using lista_presentes.DTOs;
using lista_presentes.DTOs.Usuario;
using lista_presentes.Entities;
using lista_presentes.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lista_presentes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioListagemDTO>> GetById(int id)
        {
            try
            {
                var result = await _usuarioRepository.GetUsuarioByIdAsync(id);
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
        public async Task<ActionResult<List<UsuarioListagemDTO>>> GetListagem([FromBody] FiltrosPaginacaoDTO filtros)
        {
            try
            {
                var result = await _usuarioRepository.GetUsuarioListagemAsync(filtros);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] UsuarioCadastroDTO usuario)
        {
            try
            {
                var result = await _usuarioRepository.CreateUsuarioAsync(usuario);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Update([FromBody] UsuarioCadastroDTO usuario, int id)
        {
            try
            {
                var result = await _usuarioRepository.UpdateUsuarioAsync(usuario, id);
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
                var result = await _usuarioRepository.DeleteAsync(id);
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
