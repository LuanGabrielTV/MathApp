using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mathApp.Models{
    public class Licao{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idLicao { get; set; }
        [Required]
        [MaxLength(30)]
        public string? nome { get; set; }
        public string? conteudo { get; set; }
        public int? recompensa { get; set; }
        public List<UsuarioHasLicao> Matriculas { get; set; }
        public ICollection<Atividade>? Atividades { get; set; }  = new List<Atividade>();

        // public Licao(){
        //     this.Usuarios = new HashSet<Usuario>();
        // }
    }
}