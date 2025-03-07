using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_CadastroUsuário.Models;
using WebAPI_CadastroUsuário.Services;

namespace WebAPI_CadastroUsuário.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioInterface _usuarioInterface;

        public UsuarioController(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }


        [HttpGet("usuarios")] //endpoint

        public async Task<ActionResult<List<Usuario>>> ListarUsuario()
        {
            return Ok(await _usuarioInterface.ListarUsuario());
        }

        [HttpPost("usuarios")]
        public async Task<ActionResult<Usuario>> CriarUsuario(Usuario usuarioNovo)
        {
            var newUsuario = await _usuarioInterface.CriarUsuario(usuarioNovo);
            return Ok(newUsuario);
        }

        [HttpPut("usuarios/{id}")]
        public async Task<IActionResult> AtualizarUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id) return BadRequest();
            var user = await _usuarioInterface.EditarUsuario(usuario);
            return Ok(user);
        }

        [HttpDelete("usuarios/{id}")]
        public async Task<IActionResult> DeletarUsuario(int id)
        {
            var confere = await _usuarioInterface.DeletarUsuario(id);
            if (!confere) return BadRequest();
            return NoContent();
        }

    }
}
