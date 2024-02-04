using mathApp.Models;
using mathApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace mathApp.Services
{

    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _tbUsuario;
        private readonly DbContext _context;
        public UsuarioService(IUsuarioRepository tbUsuario, DbContext context)
        {
            _tbUsuario = tbUsuario;
            _context = context;
        }

        public ActionResult<IEnumerable<Usuario>> GetUsuarios()
        {
            return _tbUsuario.GetAll();
        }

        public ActionResult<Usuario> GetUsuarioByIdUsuario(int id)
        {
            return _tbUsuario.GetById(id);
        }

        public Usuario AddUsuario(Usuario u)
        {
            _tbUsuario.Add(u);
            return u;
        }

    }

    public interface IUsuarioService
    {
        Usuario AddUsuario(Usuario u);
        ActionResult<IEnumerable<Usuario>> GetUsuarios();

        ActionResult<Usuario> GetUsuarioByIdUsuario(int id);
    }
}