using Microsoft.AspNetCore.Mvc;
using Sigma.Application.Dtos;
using Sigma.Application.Interfaces;
using Sigma.Application.Services;
using System.Threading.Tasks;

namespace Sigma.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioDto login)
        {
            var token = await _authService.LoginAsync(login.Nome, login.Senha);
            if (token == null)
                return Unauthorized("Usuário ou senha inválidos");

            return Ok(new { token });
        }
    }
}
