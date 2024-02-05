using mathApp.Models;
using mathApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace mathApp.Services
{

    public class LicaoService : ILicaoService
    {
        private readonly ILicaoRepository _TbLicao;
        private readonly DbContext _context;
        public LicaoService(ILicaoRepository tbLicao, DbContext context)
        {
            _TbLicao = tbLicao;
            _context = context;
        }

        public ActionResult<IEnumerable<Licao>> GetLicoes()
        {
            return _TbLicao.GetAll();
        }

        public ActionResult<Licao> GetLicaoByIdLicao(int id)
        {
            return _TbLicao.GetById(id);
        }

        public Licao AddLicao(Licao l)
        {
            _TbLicao.Add(l);
            return l;
        }

        public Licao UpdateLicao(Licao licao)
        {
            _TbLicao.Update(licao);
            return licao;
        }

        public Licao DeleteLicao(Licao licao)
        {
            _TbLicao.Delete(licao);
            return licao;
        }

        public Licao DeleteLicaoByIdLicao(int idLicao)
        {
            Licao licao = _TbLicao.DeleteById(idLicao);
            return licao;
        }

    }

    public interface ILicaoService
    {
        Licao AddLicao(Licao u);
        ActionResult<IEnumerable<Licao>> GetLicoes();
        ActionResult<Licao> GetLicaoByIdLicao(int id);
        Licao UpdateLicao(Licao licao);
        Licao DeleteLicao(Licao licao);
        Licao DeleteLicaoByIdLicao(int idLicao);
    }
}