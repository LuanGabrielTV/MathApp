using System.Collections.Generic;
using System.Linq;
using mathApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mathApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
         private MySQLDBContext _dbContext;  
         public UsuarioController(MySQLDBContext context)  
        {  
            _dbContext = context;  
        }  
        // GET: api/Usuario
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> GetUsuarios()
        {
            return _dbContext.Usuarios.ToList();
        }
        // GET: api/Usuario/1
        [HttpGet("{id}")]
        public ActionResult<Usuario> GetUsuario(int id)
        {
            var u = _dbContext.Usuarios.Find(id);
            if (u == null)
            {
                return NotFound();
            }
            return u;
        }

         // POST: api/Usuario
        [HttpPost]
        public ActionResult<Usuario> CreateUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }
            _dbContext.Usuarios.Add(usuario);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.idUsuario }, usuario);
        }

    }
}