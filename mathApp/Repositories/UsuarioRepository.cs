using mathApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mathApp.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DbContext _context;
        private DbSet<Usuario> _TbUsuario;
        public UsuarioRepository(DbContext context)
        {
            _context = context;
            _TbUsuario = _context.Set<Usuario>();
        }
        Usuario IUsuarioRepository.Add(Usuario usuario)
        {
            _TbUsuario.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        ActionResult<IEnumerable<Usuario>> IUsuarioRepository.GetAll()
        {
            return _TbUsuario.ToList();
        }

        ActionResult<Usuario> IUsuarioRepository.GetById(int id)
        {
            return _TbUsuario.Find(id);
        }

        Usuario IUsuarioRepository.Update(Usuario usuario)
        {
            _TbUsuario.Update(usuario);
            _context.SaveChanges();
            return usuario;
        }

        ActionResult<Usuario> IUsuarioRepository.Delete(Usuario usuario)
        {
            _TbUsuario.Remove(usuario);
            _context.SaveChanges();
            return usuario;
        }
    }
    public interface IUsuarioRepository
    {
        ActionResult<Usuario> GetById(int id);
        ActionResult<IEnumerable<Usuario>> GetAll();
        Usuario Add(Usuario usuario);
        Usuario Update(Usuario usuario);
        ActionResult<Usuario> Delete(Usuario entity);
    }
}