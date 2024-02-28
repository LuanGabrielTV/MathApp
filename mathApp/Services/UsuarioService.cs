using System.Security.Cryptography;
using mathApp.DTO;
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

        public ActionResult<Usuario?> GetUsuarioByIdUsuario(int id)
        {
            return _TbUsuario.GetById(id);
        }

        public Usuario AddUsuario(UsuarioDTO usuarioDTO, byte[] hash, byte[] salt)
        {

            Usuario u = _TbUsuario.Add(usuarioDTO, hash, salt);
            return u;
        }

        public Usuario findByCredentials(string email)
        {
            Usuario u = _TbUsuario.findByCredentials(email);
            return u;
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

        public Usuario? DeleteUsuarioByIdUsuario(int idUsuario)
        {
            Usuario? usuario = _TbUsuario.DeleteById(idUsuario);
            return usuario;
        }

        public ActionResult<IEnumerable<string>> GetUsuariosNames()
        {
            return _TbUsuario.GetUsuariosNames();
        }

        public ActionResult<UsuarioHasLicao?> matricular(int idUsuario, int idLicao)
        {
            return _TbUsuario.matricular(idUsuario, idLicao);
        }

        public ActionResult<Usuario> progredir(Object o)
        {
            return _TbUsuario.progredir(o);
        }

    }

    public interface IUsuarioService
    {
        Usuario AddUsuario(UsuarioDTO usuarioDTO, byte[] hash, byte[] salt);
        Usuario findByCredentials(string email);
        ActionResult<IEnumerable<Usuario>> GetUsuarios();
        ActionResult<Usuario?> GetUsuarioByIdUsuario(int id);
        ActionResult<UsuarioHasLicao?> matricular(int idUsuario, int idLicao);
        Usuario UpdateUsuario(Usuario usuario);
        Usuario DeleteUsuario(Usuario usuario);
        Usuario? DeleteUsuarioByIdUsuario(int idUsuario);
        ActionResult<IEnumerable<string>> GetUsuariosNames();
        ActionResult<Usuario> progredir(Object o);

    }
}