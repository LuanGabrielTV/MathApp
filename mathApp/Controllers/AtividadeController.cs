using System.Collections.Generic;
using System.Linq;
using mathApp.DTO;
using mathApp.Models;
using mathApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mathApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadeController : Controller
    {
        private IAtividadeService _atividadeService;
        private readonly DbContext _context;
        public AtividadeController(MySQLDBContext context, IAtividadeService atividadeService)
        {
            _context = context;
            _atividadeService = atividadeService;
        }
        // GET: api/Atividade
        [HttpGet]
        public ActionResult<IEnumerable<Atividade>> GetLicoes()
        {
            return _atividadeService.GetAtividades();
        }

        // GET: api/Atividade/1
        [HttpGet("{id}")]
        public ActionResult<Atividade?> GetAtividade(int id)
        {
            var a = _atividadeService.GetAtividadeByIdAtividade(id);
            if (a == null)
            {
                return NotFound();
            }
            return a;
        }

        [HttpGet("Licao/{id}")]
        public ActionResult<IEnumerable<Atividade>> GetAtividadesByIdLicao(int id)
        {
            var a = _atividadeService.GetAtividadesByIdLicao(id);
            if (a == null)
            {
                return NotFound();
            }
            return a;
        }

        // PATCH: api/Atividade
        [HttpPatch]
        public ActionResult<Atividade> UpdateAtividade(Atividade atividade)
        {
            if (atividade == null)
            {
                return BadRequest();
            }
            _atividadeService.UpdateAtividade(atividade);
            return CreatedAtAction(nameof(GetAtividade), new { id = atividade.idAtividade }, atividade);
        }

        // DELETE: api/Atividade
        [HttpDelete]
        public ActionResult<Atividade> DeleteAtividade(Atividade atividade)
        {
            if (atividade == null)
            {
                return BadRequest();
            }
            _atividadeService.DeleteAtividade(atividade);
            return CreatedAtAction(nameof(GetAtividade), new { id = atividade.idAtividade }, atividade);
        }

        // DELETE: api/Atividade/1
        [HttpDelete("{id}")]
        public ActionResult<Atividade?> DeleteAtividadeByIdAtividade(int id)
        {
            Atividade? atividade = _atividadeService.DeleteAtividadeByIdAtividade(id);
            if (atividade == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetAtividade), new { id = atividade.idAtividade }, atividade);
        }
    }

}