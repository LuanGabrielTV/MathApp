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
        Usuario IUsuarioRepository.Add(Usuario entity)
        {
            _TbUsuario.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        ActionResult<IEnumerable<Usuario>> IUsuarioRepository.GetAll()
        {
            return _TbUsuario.ToList();
        }

        ActionResult<Usuario> IUsuarioRepository.GetById(int id)
        {
            return _TbUsuario.Find(id);
        }
    }
    public interface IUsuarioRepository
    {
        ActionResult<Usuario> GetById(int id);
        ActionResult<IEnumerable<Usuario>> GetAll();
        Usuario Add(Usuario entity);
        // Task Update(Usuario entity);
        // Task Delete(Usuario entity);
    }
}