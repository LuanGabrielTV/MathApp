using mathApp.Models;
using mathApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace mathApp.Services
{

    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _TbUsuario;
        private readonly DbContext _context;
        public UsuarioService(IUsuarioRepository tbUsuario, DbContext context)
        {
            _TbUsuario = tbUsuario;
            _context = context;
        }

        public ActionResult<IEnumerable<Usuario>> GetUsuarios()
        {
            return _TbUsuario.GetAll();
        }

        public ActionResult<Usuario> GetUsuarioByIdUsuario(int id)
        {
            return _TbUsuario.GetById(id);
        }

        public Usuario AddUsuario(Usuario usuario)
        {
            _TbUsuario.Add(usuario);
            return usuario;
        }

        public Usuario UpdateUsuario(Usuario usuario)
        {
            _TbUsuario.Update(usuario);
            return usuario;
        }

        public Usuario DeleteUsuario(Usuario usuario)
        {
            _TbUsuario.Delete(usuario);
            return usuario;
        }

        public Usuario DeleteUsuarioByIdUsuario(int idUsuario)
        {
            Usuario usuario = _TbUsuario.DeleteById(idUsuario);
            return usuario;
        }

        public ActionResult<IEnumerable<string>> GetUsuariosNames()
        {
            return _TbUsuario.GetUsuariosNames();
        }

    }

    public interface IUsuarioService
    {
        Usuario AddUsuario(Usuario u);
        ActionResult<IEnumerable<Usuario>> GetUsuarios();
        ActionResult<Usuario> GetUsuarioByIdUsuario(int id);
        Usuario UpdateUsuario(Usuario usuario);
        Usuario DeleteUsuario(Usuario usuario);
        Usuario DeleteUsuarioByIdUsuario(int idUsuario);
        ActionResult<IEnumerable<string>> GetUsuariosNames();
    }
}