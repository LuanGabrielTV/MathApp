using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using mathApp.DTO;

namespace mathApp.Models{
    public class Usuario{

        public Usuario(){}

        public Usuario(UsuarioDTO usuarioDTO, byte[] hash, byte[] salt)
        {
            this.nome = usuarioDTO.nome;
            this.email = usuarioDTO.email;
            this.senha = hash;
            this.salt = salt;
            this.XP = 0;
            this.Matriculas = new List<UsuarioHasLicao>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idUsuario { get; set; }
        [Required]
        [MaxLength(15)]
        public string? nome { get; set; }
        [Required]
        public string? email { get; set; }
        [Required]
        public byte[]? senha { get; set; }
        public byte[]? salt { get; set; }
        public int? XP { get; set; }
        public List<UsuarioHasLicao>? Matriculas { get; set; }

        // public Usuario(){
            // this.Licoes = new HashSet<Licao>();
        // }
    }

  
}