using System.Collections.Generic;
using System.Linq;
using mathApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mathApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicaoController : Controller
    {
        private MySQLDBContext _dbContext;
        public LicaoController(MySQLDBContext context)
        {
            _dbContext = context;
        }
        // GET: api/Licao
        [HttpGet]
        public ActionResult<IEnumerable<Licao>> GetLicoes()
        {
            return _dbContext.Licoes.ToList();
        }

        // GET: api/Licao/1
        [HttpGet("{id}")]
        public ActionResult<Licao> GetLicao(int id)
        {
            var l = _dbContext.Licoes.Find(id);
            if (l == null)
            {
                return NotFound();
            }
            return l;
        }


         // POST: api/Usuario
        [HttpPost]
        public ActionResult<Usuario> CreateUsuario(Licao licao)
        {
            if (licao == null)
            {
                return BadRequest();
            }
            _dbContext.Licoes.Add(licao);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetLicao), new { id = licao.idLicao }, licao);
        }
    }

}