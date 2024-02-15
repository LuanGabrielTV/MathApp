using System.Collections.ObjectModel;
using mathApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mathApp.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DbContext _context;
        private DbSet<Usuario> _TbUsuario;
        private DbSet<Licao> _TbLicao;
        public UsuarioRepository(DbContext context)
        {
            _context = context;
            _TbUsuario = _context.Set<Usuario>();
            _TbLicao = _context.Set<Licao>();
        }
        Usuario IUsuarioRepository.Add(Usuario usuario)
        {
            usuario.Licoes = new List<Licao>();
            Licao? intro = _TbLicao.Find(1);
            if (intro != null)
            {
                usuario.Licoes.Add(intro);
            }
            _TbUsuario.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        ActionResult<IEnumerable<Usuario>> IUsuarioRepository.GetAll()
        {
            return _TbUsuario.Include(u => u.Licoes).ToList();
        }

        ActionResult<Usuario?> IUsuarioRepository.GetById(int id)
        {
            return _TbUsuario.Find(id);
        }

        ActionResult<List<Licao>?> IUsuarioRepository.GetLicoesByUsuario(int id)
        {
            
            Usuario? usuario = (_TbUsuario.Include(u => u.Licoes).Single(u => u.idUsuario == id));
            return usuario?.Licoes;
        }

        Usuario IUsuarioRepository.Update(Usuario usuario)
        {
            _TbUsuario.Update(usuario);
            _context.SaveChanges();
            return usuario;
        }

        Usuario? IUsuarioRepository.DeleteById(int idUsuario)
        {
            Usuario? usuario = _TbUsuario.Find(idUsuario);
            if (usuario != null)
            {
                _TbUsuario.Remove(usuario);
                _context.SaveChanges();
                return usuario;
            }
            return null;
        }

        Usuario IUsuarioRepository.Delete(Usuario usuario)
        {
            _TbUsuario.Remove(usuario);
            _context.SaveChanges();
            return usuario;
        }

        ActionResult<IEnumerable<string>> IUsuarioRepository.GetUsuariosNames()
        {
            return _TbUsuario.Select(u => u.nome).ToList();
        }
    }
    public interface IUsuarioRepository
    {
        ActionResult<Usuario?> GetById(int id);
        ActionResult<IEnumerable<Usuario>> GetAll();
        Usuario Add(Usuario usuario);
        Usuario Update(Usuario usuario);
        Usuario? DeleteById(int idUsuario);
        Usuario Delete(Usuario usuario);
        ActionResult<IEnumerable<string>> GetUsuariosNames();
        ActionResult<List<Licao>?> GetLicoesByUsuario(int id);
    }
}