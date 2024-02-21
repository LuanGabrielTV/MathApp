using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using mathApp.DTO;
using mathApp.Models;
using mathApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace mathApp.Controllers
{
    [Route("api")]
    [ApiController]

    public class AuthController : Controller
    {
        private IUsuarioService _usuarioService;
        private readonly DbContext _context;

        private readonly IConfiguration _configuration;

        public AuthController(MySQLDBContext context, IUsuarioService usuarioService, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
            _usuarioService = usuarioService;

        }

        [HttpPost("register")]
        public ActionResult<Usuario> AddUsuario(UsuarioDTO request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            byte[] hash, salt;
            using (var hmac = new HMACSHA512())
            {
                hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(request.senha));
                salt = hmac.Key;
            }
            Console.WriteLine(hash.ToString());
            Usuario u = _usuarioService.AddUsuario(request, hash, salt);
            return Ok(u);
        }

        [HttpPost("login")]
        public String? loginUsuario(UsuarioDTO request)
        {

            if (request == null)
            {
                return null;
            }

            byte[] hashComputado;
            Usuario u = _usuarioService.findByCredentials(request.email);
            if (u == null)
            {
                return null;
            }
            using (var hmac = new HMACSHA512(u.salt))
            {
                hashComputado = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(request.senha));
            }
            Console.WriteLine(hashComputado.ToString());
            if(!u.senha.SequenceEqual(hashComputado))
            {
                return null;
            }
            UsuarioDTO usuarioDTO = new UsuarioDTO(u);
            string token = criarToken(usuarioDTO);

            return token;

        }

        private string criarToken(UsuarioDTO u)
        {
            List<Claim> claims = new List<Claim> { new Claim("email", u.email), new Claim("nome", u.nome), new Claim("id", u.id.ToString()) };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

    }


}