using System.Collections.Generic;
using System.Linq;
using mathApp.Models;
using mathApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mathApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private IUsuarioService _usuarioService;
        private readonly DbContext _context;
        public UsuarioController(IUsuarioService usuarioService, DbContext context)
        {
            _context = context;
            _usuarioService = usuarioService;
        }
        // GET: api/Usuario
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> GetUsuarios()
        {
            return _usuarioService.GetUsuarios();
        }
        // GET: api/Usuario/1
        [HttpGet("{id}")]
        public ActionResult<Usuario> GetUsuario(int id)
        {
            var u = _usuarioService.GetUsuarioByIdUsuario(id);
            if (u == null)
            {
                return NotFound();
            }
            return u;
        }

        // POST: api/Usuario
        [HttpPost]
        public ActionResult<Usuario> AddUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }
            _usuarioService.AddUsuario(usuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.idUsuario }, usuario);
        }
        
        // PATCH: api/Usuario
        [HttpPatch]
        public ActionResult<Usuario> UpdateUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }
            _usuarioService.UpdateUsuario(usuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.idUsuario }, usuario);
        }
        
        // DELETE: api/Usuario
        [HttpDelete]
        public ActionResult<Usuario> DeleteUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }
            _usuarioService.DeleteUsuario(usuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.idUsuario }, usuario);
        }
    }
}