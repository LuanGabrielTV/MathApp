using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mathApp.Models
{
    public class UsuarioHasLicao
    {
        public int idUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public int idLicao { get; set; }
        public Licao Licao { get; set; }
        public Boolean isFinished { get; set; }

        public UsuarioHasLicao(){}

        public UsuarioHasLicao(Usuario usuario, Licao licao){
            this.idUsuario = usuario.idUsuario;
            this.Usuario = usuario;
            this.idLicao = licao.idLicao;
            this.Licao = licao;
            this.isFinished = false;
        }
    }
}