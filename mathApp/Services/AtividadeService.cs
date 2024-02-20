using mathApp.DTO;
using mathApp.Models;
using mathApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace mathApp.Services
{

    public class AtividadeService : IAtividadeService
    {
        private readonly IAtividadeRepository _TbAtividade;
        private readonly DbContext _context;
        public AtividadeService(IAtividadeRepository tbAtividade, DbContext context)
        {
            _TbAtividade = tbAtividade;
            _context = context;
        }

        public ActionResult<IEnumerable<Atividade>> GetAtividades()
        {
            return _TbAtividade.GetAll();
        }

        public ActionResult<Atividade?> GetAtividadeByIdAtividade(int id)
        {
            return _TbAtividade.GetById(id);
        }

         public ActionResult<IEnumerable<Atividade>> GetAtividadesByIdLicao(int idLicao)
        {
            return _TbAtividade.GetByIdLicao(idLicao);
        }

        public Atividade UpdateAtividade(Atividade atividade)
        {
            _TbAtividade.Update(atividade);
            return atividade;
        }

        public Atividade DeleteAtividade(Atividade atividade)
        {
            _TbAtividade.Delete(atividade);
            return atividade;
        }

        public Atividade? DeleteAtividadeByIdAtividade(int idAtividade)
        {
            Atividade? atividade = _TbAtividade.DeleteById(idAtividade);
            return atividade;
        }

    }

    public interface IAtividadeService
    {
        ActionResult<IEnumerable<Atividade>> GetAtividades();
        ActionResult<Atividade?> GetAtividadeByIdAtividade(int id);
        ActionResult<IEnumerable<Atividade>> GetAtividadesByIdLicao(int idLicao);
        Atividade UpdateAtividade(Atividade atividade);
        Atividade DeleteAtividade(Atividade atividade);
        Atividade? DeleteAtividadeByIdAtividade(int idAtividade);
    }
}