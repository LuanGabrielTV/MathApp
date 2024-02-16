using System.Collections.ObjectModel;
using mathApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mathApp.Repositories
{
    public class UsuarioHasLicaoRepository : IUsuarioHasLicaoRepository
    {
        private readonly DbContext _context;
        private DbSet<UsuarioHasLicao> _TbUsuarioHasLicao;
        public UsuarioHasLicaoRepository(DbContext context)
        {
            _context = context;
            _TbUsuarioHasLicao = _context.Set<UsuarioHasLicao>();
        }

        ActionResult<IEnumerable<UsuarioHasLicao>> IUsuarioHasLicaoRepository.GetAll(){
            return _TbUsuarioHasLicao.Include(m => m.Usuario).Include(m => m.Licao).ToList();
        }

        ActionResult<IEnumerable<UsuarioHasLicao>> IUsuarioHasLicaoRepository.GetMatriculasByUsuario(int idUsuario){
            return _TbUsuarioHasLicao.Where(m => m.idUsuario == idUsuario).ToList();
        }

        ActionResult<IEnumerable<UsuarioHasLicao>> IUsuarioHasLicaoRepository.GetMatriculasByLicao(int idLicao){
            return _TbUsuarioHasLicao.Where(m => m.idLicao == idLicao).ToList();
        }

    }
    public interface IUsuarioHasLicaoRepository
    {
        ActionResult<IEnumerable<UsuarioHasLicao>> GetAll();
        ActionResult<IEnumerable<UsuarioHasLicao>> GetMatriculasByUsuario(int idUsuario);
        ActionResult<IEnumerable<UsuarioHasLicao>> GetMatriculasByLicao(int idLicao);

    }
}