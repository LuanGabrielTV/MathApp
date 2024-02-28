using System.Collections.ObjectModel;
using mathApp.DTO;
using mathApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        Usuario IUsuarioRepository.Add(UsuarioDTO usuarioDTO, byte[] hash, byte[] salt)
        {
            Usuario usuario = new Usuario(usuarioDTO, hash, salt);
            Licao? intro = _TbLicao.Find(1);
            _TbUsuario.Add(usuario);
            _context.SaveChanges();
            if (intro != null)
            {
                UsuarioHasLicao mat = new UsuarioHasLicao(usuario, intro);
                _TbMatricula.Add(mat);
            }
            _context.SaveChanges();
            return usuario;
        }

        Usuario IUsuarioRepository.findByCredentials(string email)
        {
            Usuario u = _TbUsuario.Where(u => u.email == email).FirstOrDefault();
            if (u == null)
            {
                return null;
            }
            return u;
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

        ActionResult<UsuarioHasLicao> IUsuarioRepository.matricular(int idUsuario, int idLicao)
        {
            Usuario u = _TbUsuario.Find(idUsuario);
            Licao l = _TbLicao.Find(idLicao);
            if (u != null && l != null)
            {
                UsuarioHasLicao mat = new UsuarioHasLicao(u, l);
                _TbMatricula.Add(mat);
                _context.SaveChanges();
                return mat;
            }
            return null;
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

        Usuario IUsuarioRepository.progredir(object o){
            var info =  JObject.Parse(o.ToString());
            Console.Write(info["idUsuario"].ToString());
            Usuario? usuario = _TbUsuario.Find(info["idUsuario"].Value<int>());
            if(usuario != null){
                usuario.XP += info["XP"].Value<int>();
                _TbUsuario.Update(usuario);
                _context.SaveChanges();
                Console.WriteLine("100");
                return usuario;
            }
            Console.WriteLine("103");
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
        Usuario findByCredentials(string email);
        ActionResult<IEnumerable<Usuario>> GetAll();
        Usuario Add(UsuarioDTO usuarioDTO, byte[] hash, byte[] salt);
        Usuario Update(Usuario usuario);
        Usuario? DeleteById(int idUsuario);
        Usuario Delete(Usuario usuario);
        Usuario progredir(Object o);
        ActionResult<UsuarioHasLicao> matricular(int idUsuario, int idLicao);
        ActionResult<IEnumerable<string>> GetUsuariosNames();
    }
}