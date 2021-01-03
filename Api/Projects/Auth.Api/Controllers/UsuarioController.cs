using Auth.Biz.Interface;
using Auth.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        [HttpGet]
        public ActionResult<dynamic> CriarUsuario(Usuario user)
        {
            var ret = _service.CriarUsuario(user);

            if (ret.IsValid)
                return Ok(ret.Objeto);
            else
                return BadRequest(ret.Erros);
        }
    }
}
