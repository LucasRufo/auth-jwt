using Auth.Biz.Interface;
using Auth.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Api.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize]
        public ActionResult CriarUsuario(Usuario user)
        {
            var ret = _service.CriarUsuario(user);

            if (ret.IsValid)
                return Ok(new { Success = true });
            else
                return BadRequest(ret.Erros);
        }
    }
}
