using mathApp.Models;
using mathApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace mathApp.Services
{

    public class UsuarioHasLicaoService : IUsuarioHasLicaoService
    {
        private readonly IUsuarioHasLicaoRepository _TbUsuarioHasLicao;
        private readonly DbContext _context;
        public UsuarioHasLicaoService(IUsuarioHasLicaoRepository tbUsuarioHasLicao, DbContext context)
        {
            _TbUsuarioHasLicao = tbUsuarioHasLicao;
            _context = context;
        }

        public ActionResult<IEnumerable<UsuarioHasLicao>> GetMatriculas()
        {
            return _TbUsuarioHasLicao.GetAll();
        }

        public ActionResult<IEnumerable<UsuarioHasLicao>> GetMatriculasByUsuario(int idUsuario)
        {
            return _TbUsuarioHasLicao.GetMatriculasByUsuario(idUsuario);
        }

        public ActionResult<IEnumerable<UsuarioHasLicao>> GetMatriculasByLicao(int idLicao)
        {
            return _TbUsuarioHasLicao.GetMatriculasByLicao(idLicao);
        }

    }

    public interface IUsuarioHasLicaoService
    {
        ActionResult<IEnumerable<UsuarioHasLicao>> GetMatriculas();
        ActionResult<IEnumerable<UsuarioHasLicao>> GetMatriculasByUsuario(int idUsuario);
        ActionResult<IEnumerable<UsuarioHasLicao>> GetMatriculasByLicao(int idLicao);
    }
}