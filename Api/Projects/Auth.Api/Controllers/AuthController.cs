using Auth.Biz.Core;
using Auth.Biz.Interface;
using Auth.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUsuarioService _service;

        public AuthController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Authenticate(Login login)
        {
            var usuario = _service.ObterUsuarioLogin(login.Email, login.Senha);

            if(usuario == null)
                return NotFound(new { Mensagem = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(usuario);

            usuario.Senha = "";

            return Ok(new
            {
                Usuario = usuario,
                Token = token
            });
        }
    }
}
