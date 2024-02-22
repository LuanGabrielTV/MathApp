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
    public class LicaoController : Controller
    {
        private ILicaoService _licaoService;
        private readonly DbContext _context;
        private readonly IConfiguration _configuration;
        public LicaoController(MySQLDBContext context, ILicaoService licaoService, IConfiguration configuration)
        {
            _context = context;
            _licaoService = licaoService;
            _configuration = configuration;
        }
        // GET: api/Licao
        [HttpGet]
        public ActionResult<IEnumerable<Licao>> GetLicoes([FromHeader] string token)
        {
            if (validarToken(token) == null)
            {
                return Unauthorized();
            }
            return _licaoService.GetLicoes();
        }

        // GET: api/Licao/1
        [HttpGet("{id}")]
        public ActionResult<Licao?> GetLicao(int id)
        {
            var l = _licaoService.GetLicaoByIdLicao(id);
            if (l == null)
            {
                return NotFound();
            }
            return l;
        }

         // GET: api/Licao/1
        [HttpGet("Inicio/{id}")]
        public ActionResult GetFrontPageLicoes(int id, [FromHeader] string token)
        {
            if (validarToken(token) == null)
            {
                return Unauthorized();
            }
            var licoes = _licaoService.GetFrontPageLicoes(id);
            if (licoes == null)
            {
                return NotFound();
            }
            return Ok(licoes.Value);
        }

        // POST: api/Licao
        [HttpPost]
        public ActionResult<Licao> AddLicao(Licao licao)
        {
            if (licao == null)
            {
                return BadRequest();
            }
            _licaoService.AddLicao(licao);
            return CreatedAtAction(nameof(GetLicao), new { id = licao.idLicao }, licao);
        }

        // POST: api/Licao
        [HttpPost("Atividade")]
        public ActionResult<Atividade> AddAtividade(AtividadeDTO atividadeDto)
        {
            if (atividadeDto == null)
            {
                return BadRequest();
            }
            _licaoService.AddAtividade(atividadeDto);
            return CreatedAtAction(nameof(GetLicao), new { id = atividadeDto.enunciado }, atividadeDto);
        }

        // PATCH: api/Licao
        [HttpPatch]
        public ActionResult<Licao> UpdateLicao(Licao licao)
        {
            if (licao == null)
            {
                return BadRequest();
            }
            _licaoService.UpdateLicao(licao);
            return CreatedAtAction(nameof(GetLicao), new { id = licao.idLicao }, licao);
        }

        // DELETE: api/Licao
        [HttpDelete]
        public ActionResult<Licao> DeleteLicao(Licao licao)
        {
            if (licao == null)
            {
                return BadRequest();
            }
            _licaoService.DeleteLicao(licao);
            return CreatedAtAction(nameof(GetLicao), new { id = licao.idLicao }, licao);
        }

        // DELETE: api/Licao/1
        [HttpDelete("{id}")]
        public ActionResult<Licao?> DeleteLicaoByIdLicao(int id)
        {
            Licao? licao = _licaoService.DeleteLicaoByIdLicao(id);
            if (licao == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetLicao), new { id = licao.idLicao }, licao);
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