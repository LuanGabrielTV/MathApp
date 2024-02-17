using System.Collections.ObjectModel;
using mathApp.DTO;
using mathApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mathApp.Repositories
{
    public class AtividadeRepository : IAtividadeRepository
    {
        private readonly DbContext _context;
        private DbSet<Atividade> _TbAtividade;
        public AtividadeRepository(DbContext context)
        {
            _context = context;
            _TbAtividade = _context.Set<Atividade>();
        }
        Atividade IAtividadeRepository.Add(AtividadeDTO atividadeDto)
        {
            Atividade atividade = new Atividade(atividadeDto);
            _TbAtividade.Add(atividade);
            _context.SaveChanges();
            return atividade;
        }

        ActionResult<IEnumerable<Atividade>> IAtividadeRepository.GetAll()
        {
            return _TbAtividade.ToList();
        }

        ActionResult<Atividade?> IAtividadeRepository.GetById(int id)
        {
            return _TbAtividade.Find(id);
        }
        ActionResult<IEnumerable<Atividade>> IAtividadeRepository.GetByIdLicao(int idLicao)
        {
            return _TbAtividade.Where(a => a.idLicao == idLicao).ToList();
        }

        Atividade IAtividadeRepository.Update(Atividade atividade)
        {
            _TbAtividade.Update(atividade);
            _context.SaveChanges();
            return atividade;
        }

        Atividade IAtividadeRepository.Delete(Atividade atividade)
        {
            _TbAtividade.Remove(atividade);
            _context.SaveChanges();
            return atividade;
        }

        Atividade? IAtividadeRepository.DeleteById(int idAtividade)
        {
            Atividade atividade = _TbAtividade.Find(idAtividade);
            if (atividade != null)
            {
                _TbAtividade.Remove(atividade);
                _context.SaveChanges();
                return atividade;

            }
            return null;
        }
        

    }
    public interface IAtividadeRepository
    {
        ActionResult<Atividade?> GetById(int id);
        ActionResult<IEnumerable<Atividade>> GetByIdLicao(int idLicao);
        ActionResult<IEnumerable<Atividade>> GetAll();
        Atividade Add(AtividadeDTO atividadeDto);
        Atividade Update(Atividade atividade);
        Atividade Delete(Atividade atividade);
        Atividade? DeleteById(int idAtividade);
        
    }
}