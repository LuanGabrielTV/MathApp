using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using mathApp.DTO;
using mathApp.Models;
using mathApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace mathApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private IUsuarioService _usuarioService;
        private readonly DbContext _context;
        private readonly IConfiguration _configuration;
        public UsuarioController(IUsuarioService usuarioService, DbContext context, IConfiguration configuration)
        {
            _context = context;
            _usuarioService = usuarioService;
            _configuration = configuration;
        }
        // GET: api/Usuario
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> GetUsuarios([FromHeader] string token)
        {
            if (validarToken(token) == null)
            {
                return Unauthorized();
            }
            return _usuarioService.GetUsuarios();
        }
        // GET: api/Usuario/1
        [HttpGet("{id}")]
        public ActionResult<Usuario?> GetUsuario([FromHeader] string token, int id)
        {
            if (validarToken(token) == null)
            {
                return Unauthorized();
            }
            var u = _usuarioService.GetUsuarioByIdUsuario(id);
            if (u == null)
            {
                return NotFound();
            }
            return u;
        }

        [HttpPost("progredir")]
        public ActionResult<Usuario> progredir([FromHeader] string token, Object o){
            if(validarToken(token) == null){
                return Unauthorized();
            }
            return _usuarioService.progredir(o);
        }

        // PATCH: api/Usuario
        [HttpPatch]
        public ActionResult<Usuario> UpdateUsuario([FromHeader] string token, Usuario usuario)
        {
            if (validarToken(token) == null)
            {
                return Unauthorized();
            }
            if (usuario == null)
            {
                return BadRequest();
            }
            _usuarioService.UpdateUsuario(usuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.idUsuario }, usuario);
        }

        // DELETE: api/Usuario/
        [HttpDelete]
        public ActionResult<Usuario> DeleteUsuarioByIdUsuario(Usuario usuario)
        {

            if (usuario == null)
            {
                return BadRequest();
            }
            _usuarioService.DeleteUsuario(usuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.idUsuario }, usuario);
        }

        // DELETE: api/Usuario/1
        [HttpDelete("{id}")]
        public ActionResult<Usuario?> DeleteUsuarioByIdUsuario(int id)
        {
            Usuario? usuario = _usuarioService.DeleteUsuarioByIdUsuario(id);
            if (usuario == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.idUsuario }, usuario);
        }

        [HttpGet("nomes")]
        public ActionResult<IEnumerable<string>> GetUsuariosNames()
        {
            return _usuarioService.GetUsuariosNames();
        }

        [HttpGet("matricular/{idUsuario}/{idLicao}")]
        public ActionResult<UsuarioHasLicao> matricular(int idUsuario, int idLicao)
        {
            if(idUsuario!=null && idLicao!=null){
                return _usuarioService.matricular(idUsuario, idLicao);
            }
            return BadRequest();
        }


        private UsuarioDTO? validarToken(string token)
        {
            if (token == null)
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                int id = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
                string email = jwtToken.Claims.First(x => x.Type == "email").Value;
                string nome = jwtToken.Claims.First(x => x.Type == "nome").Value;

                return new UsuarioDTO(nome, email, id);
            }
            catch
            {
                return null;
            }
        }
    }
}