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
    public class LicaoController : Controller
    {
        private ILicaoService _licaoService;
        private readonly DbContext _context;
        public LicaoController(MySQLDBContext context, ILicaoService licaoService)
        {
            _context = context;
            _licaoService = licaoService;
        }
        // GET: api/Licao
        [HttpGet]
        public ActionResult<IEnumerable<Licao>> GetLicoes()
        {
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
    }

}