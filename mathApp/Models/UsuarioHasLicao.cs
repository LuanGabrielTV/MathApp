using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace mathApp.Models
{
    public class UsuarioHasLicao
    {
        public int idUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public int idLicao { get; set; }
        public Licao? Licao { get; set; }
        public Boolean isFinished { get; set; }

        public UsuarioHasLicao(){
            this.isFinished = false;
        }

        public UsuarioHasLicao(Usuario u){
            this.idUsuario = u.idUsuario;
            this.Usuario = u;
            this.isFinished = false;
        }

        public UsuarioHasLicao(Usuario u, Licao l){
            this.idUsuario = u.idUsuario;
            this.Usuario = u;
            this.Licao = l;
            this.idLicao = l.idLicao;
            this.isFinished = false;
        }

        public void addLicao(Licao l){
            this.Licao = l;
            this.idLicao = l.idLicao;
        }

        public void finalizarLicao(){
            this.isFinished = true;
        }
    }
}