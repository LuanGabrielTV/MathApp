using mathApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mathApp.Repositories
{
    public class LicaoRepository : ILicaoRepository
    {
        private readonly DbContext _context;
        private DbSet<Licao> _TbLicao;
        public LicaoRepository(DbContext context)
        {
            _context = context;
            _TbLicao = _context.Set<Licao>();
        }
        Licao ILicaoRepository.Add(Licao licao)
        {
            _TbLicao.Add(licao);
            _context.SaveChanges();
            return licao;
        }

        ActionResult<IEnumerable<Licao>> ILicaoRepository.GetAll()
        {
            return _TbLicao.ToList();
        }

        ActionResult<Licao> ILicaoRepository.GetById(int id)
        {
            return _TbLicao.Find(id);
        }
    }
    public interface ILicaoRepository
    {
        ActionResult<Licao> GetById(int id);
        ActionResult<IEnumerable<Licao>> GetAll();
        Licao Add(Licao entity);
        // Task Update(Licao entity);
        // Task Delete(Licao entity);
    }
}