using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mathApp.Models{
    public class Licao{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idLicao { get; set; }
        [Required]
        [MaxLength(30)]
        public required string nome { get; set; }
        public required string conteudo { get; set; }
        public int recompensa { get; set; }
        public IList<UsuarioHasLicao> UsuarioHasLicao { get; set; }
    }
}