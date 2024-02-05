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

        Licao ILicaoRepository.Update(Licao licao)
        {
            _TbLicao.Update(licao);
            _context.SaveChanges();
            return licao;
        }

        Licao ILicaoRepository.Delete(Licao licao)
        {
            _TbLicao.Remove(licao);
            _context.SaveChanges();
            return licao;
        }

        Licao? ILicaoRepository.DeleteById(int idLicao)
        {
            Licao licao = _TbLicao.Find(idLicao);
            if (licao != null)
            {
                _TbLicao.Remove(licao);
                _context.SaveChanges();
                return licao;

            }
            return null;
        }
    }
    public interface ILicaoRepository
    {
        ActionResult<Licao> GetById(int id);
        ActionResult<IEnumerable<Licao>> GetAll();
        Licao Add(Licao licao);
        Licao Update(Licao licao);
        Licao Delete(Licao licao);
        Licao DeleteById(int idLicao);
    }
}