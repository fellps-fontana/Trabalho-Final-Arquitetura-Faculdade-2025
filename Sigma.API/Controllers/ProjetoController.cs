using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Sigma.Application.Dtos;
using Sigma.Application.Interfaces;
using Sigma.Domain.Dtos;
using Sigma.Domain.Enums;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sigma.API.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoService _projetoService;

        public ProjetoController(IProjetoService projetoService)
        {
            _projetoService = projetoService;
        }

        [HttpPost("inserir")]
        public async Task<IActionResult> Inserir([FromBody] ProjetoDto model)
        {
            return new JsonResult(await _projetoService.Inserir(model));
        }

        [HttpGet("BuscarTodos")]
        public async Task<IActionResult> Buscar()
        {
            var projetos = await _projetoService.BuscarTodos();
            return Ok(projetos);
        }

        [HttpGet("FiltroStatus")]
        public async Task<IActionResult> BuscarPeloStatus(StatusProjeto status)
        {
            if (status >= 0)
            {
                var projetos = await _projetoService.BuscarPeloStatus(status);
                return Ok(projetos);
            }

            return BadRequest();
        }

        [HttpGet("FiltroId")]
        public async Task<IActionResult> BuscarPeloId(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id inválido fornecido.");
            }

            var projeto = await _projetoService.BuscarPeloId(id);

            if (projeto == null)
            {
                return NotFound($"Projeto com id {id} não encontrado.");
            }

            return Ok(projeto);
        }

        [HttpPut("Atualizar {id}")]

        public async Task<IActionResult> Atualizar(int id, [FromBody] ProjetoDtoAtualizacao dto)
        {
            if (id <= 0)
                return BadRequest("Id inválido.");

            var resultado = await _projetoService.Atualizar(id, dto);

            if (!resultado)
                return NotFound($"Projeto com id {id} não encontrado.");

            return Ok($"O projeto de id:{id} foi alterado com sucesso ");
        }
        [HttpDelete("Deletar  {id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            if (id <= 0) return BadRequest("Id inválido.");

            var projetoExiste = await _projetoService.BuscarPeloId(id);
            if (projetoExiste == null)
                return NotFound($"Projeto com id {id} não encontrado.");

            var resultado = await _projetoService.Deletar(id);
            if (!resultado)
                return BadRequest($"Projeto com id {id} não pode ser deletado no status atual.");

            return Ok($"Projeto com id {id} deletado com sucesso.");
        }
    }
}
    
