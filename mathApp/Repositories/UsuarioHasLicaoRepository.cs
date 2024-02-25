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
            return _TbUsuarioHasLicao.Include(m => m.Licao).Where(m => m.idUsuario == idUsuario).ToList();
        }

        ActionResult<IEnumerable<UsuarioHasLicao>> IUsuarioHasLicaoRepository.GetMatriculasByLicao(int idLicao){
            return _TbUsuarioHasLicao.Include(m => m.Licao).Include(m => m.Usuario).Where(m => m.idLicao == idLicao).ToList();
        }

        ActionResult<UsuarioHasLicao> IUsuarioHasLicaoRepository.switchMatricula(int idUsuario, int idLicao){
            UsuarioHasLicao m = _TbUsuarioHasLicao.Include(m => m.Licao).Include(m => m.Usuario).Single(m => m.idUsuario == idUsuario && m.idLicao==idLicao);
            m.isFinished = !m.isFinished;
            _context.SaveChanges();
            return m;
        }

        UsuarioHasLicao? IUsuarioHasLicaoRepository.DeleteMatriculasByIDs(int idUsuario, int idLicao)
        {
            UsuarioHasLicao? mat = _TbUsuarioHasLicao.Single(m => m.idUsuario == idUsuario && m.idLicao == idLicao);

            if (mat != null)
            {
                _TbUsuarioHasLicao.Remove(mat);
                _context.SaveChanges();
                return mat;
            }
            return null;
        }

    }
    public interface IUsuarioHasLicaoRepository
    {
        ActionResult<IEnumerable<UsuarioHasLicao>> GetAll();

        ActionResult<UsuarioHasLicao> switchMatricula(int idUsuario, int idLicao);
        ActionResult<IEnumerable<UsuarioHasLicao>> GetMatriculasByUsuario(int idUsuario);
        ActionResult<IEnumerable<UsuarioHasLicao>> GetMatriculasByLicao(int idLicao);
        UsuarioHasLicao? DeleteMatriculasByIDs(int idUsuario, int idLicao);

    }
}