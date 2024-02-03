using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mathApp.Models
{
    public class UsuarioHasLicao
    {
        public int idUsuario { get; set; }
        public required Usuario Usuario { get; set; }
        public int idLicao { get; set; }
        public required Licao Licao { get; set; }
        public Boolean isFinished { get; set; }
        public Boolean isBlocked { get; set; }
    }
}