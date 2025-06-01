using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sigma.Application.Dtos;
using Sigma.Application.Interfaces;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost]
    public async Task<IActionResult> Inserir([FromBody] UsuarioDto model)
    {
        var sucesso = await _usuarioService.Inserir(model);
        if (!sucesso)
            return BadRequest("Erro ao criar usuário");
        return CreatedAtAction(nameof(BuscarPeloId), new { id = model.Id }, model);
    }

    [HttpGet("buscarPorNome/{nome}")]
    public async Task<IActionResult> BuscarPeloNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            return BadRequest("Nome inválido.");

        var usuario = await _usuarioService.BuscarPeloNome(nome);
        if (usuario == null)
            return NotFound();

        return Ok(usuario);
    }


    [HttpGet]
    public async Task<IActionResult> BuscarTodos()
    {
        var usuarios = await _usuarioService.BuscarTodos();
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPeloId(int id)
    {
        if (id <= 0)
            return BadRequest("Id inválido");

        var usuario = await _usuarioService.BuscarPeloId(id);
        if (usuario == null)
            return NotFound();

        return Ok(usuario);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] UsuarioDto model)
    {
        if (id <= 0)
            return BadRequest("Id inválido.");

        var sucesso = await _usuarioService.Atualizar(id, model);
        if (!sucesso)
            return NotFound($"Usuário com id {id} não encontrado.");

        return NoContent();  
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        if (id <= 0)
            return BadRequest("Id inválido");

        var sucesso = await _usuarioService.Deletar(id);
        if (!sucesso)
            return NotFound();

        return NoContent();
    }
}
