using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mathApp.Models{
    public class Licao{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idLicao { get; set; }
        [Required]
        [MaxLength(30)]
        public string nome { get; set; }
        public string conteudo { get; set; }
        public int recompensa { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }

        public Licao(){
            this.Usuarios = new HashSet<Usuario>();
        }
    }
}