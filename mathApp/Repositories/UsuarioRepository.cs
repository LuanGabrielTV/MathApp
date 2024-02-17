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

        private DbSet<UsuarioHasLicao> _TbMatricula;
        public UsuarioRepository(DbContext context)
        {
            _context = context;
            _TbUsuario = _context.Set<Usuario>();
            _TbLicao = _context.Set<Licao>();
            _TbMatricula = _context.Set<UsuarioHasLicao>();
        }
        Usuario IUsuarioRepository.Add(Usuario usuario)
        {
            Licao? intro = _TbLicao.Find(1);
            usuario.Matriculas = new List<UsuarioHasLicao>();
            _TbUsuario.Add(usuario);
            _context.SaveChanges();
            if (intro != null)
            {
                UsuarioHasLicao mat = new UsuarioHasLicao(usuario, intro);
                Console.Write(mat.Licao.nome);
                Console.Write(mat.Usuario.nome);
                _TbMatricula.Add(mat);
            }
            _context.SaveChanges();
            return usuario;
        }

        ActionResult<IEnumerable<Usuario>> IUsuarioRepository.GetAll()
        {
            return _TbUsuario.Include(u => u.Matriculas).ThenInclude(m => m.Licao).ToList();
        }

        ActionResult<Usuario?> IUsuarioRepository.GetById(int id)
        {
            return _TbUsuario.Include(u => u.Matriculas).Single(u => u.idUsuario == id);
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
    }
}