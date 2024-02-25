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
    public class UsuarioHasLicaoController : Controller
    {
        private IUsuarioHasLicaoService _usuarioHasLicaoService;
        private readonly DbContext _context;
        public UsuarioHasLicaoController(IUsuarioHasLicaoService usuarioHasLicaoService, DbContext context)
        {
            _context = context;
            _usuarioHasLicaoService = usuarioHasLicaoService;
        }
        // GET: api/Usuario
        [HttpGet]
        public ActionResult<IEnumerable<UsuarioHasLicao>> GetMatriculas()
        {
            return _usuarioHasLicaoService.GetMatriculas();
        }
        // GET: api/Usuario/1
        [HttpGet("Usuario/{id}")]
        public ActionResult<IEnumerable<UsuarioHasLicao>> GetMatriculasByUsuario(int id)
        {
            var m = _usuarioHasLicaoService.GetMatriculasByUsuario(id);
            if (m == null)
            {
                return NotFound();
            }
            return m;
        }

         // GET: api/Licao/1
        [HttpGet("Licao/{id}")]
        public ActionResult<IEnumerable<UsuarioHasLicao>> GetMatriculasByLicao(int id)
        {
            var m = _usuarioHasLicaoService.GetMatriculasByLicao(id);
            if (m == null)
            {
                return NotFound();
            }
            return m;
        }

        // PATCH
        [HttpPatch("{idUsuario}/{idLicao}")]
        public ActionResult<Object> PatchMatricula(int idUsuario, int idLicao){
            if(idUsuario == null || idLicao == null){
                return BadRequest();
            }
            var matricula = _usuarioHasLicaoService.switchMatricula(idUsuario, idLicao);
            return Ok(matricula);
        }

        [HttpDelete("{idUsuario}/{idLicao}")]
        public ActionResult<UsuarioHasLicao> DeleteMatriculasByIDs(int idUsuario, int idLicao)
        {
            var m = _usuarioHasLicaoService.DeleteMatriculasByIDs(idUsuario, idLicao);
            if (m == null)
            {
                return NotFound();
            }
            return m;
        }

    }
}