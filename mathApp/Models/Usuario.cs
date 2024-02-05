using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mathApp.Models{
    public class Usuario{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idUsuario { get; set; }
        [Required]
        [MaxLength(15)]
        public string nome { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        [MaxLength(15)]
        public string senha { get; set; }
        public int XP { get; set; }
        public IList<UsuarioHasLicao> UsuarioHasLicao { get; set; }
    }

  
}