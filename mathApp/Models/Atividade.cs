using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using mathApp.DTO;
using Microsoft.EntityFrameworkCore;

namespace mathApp.Models
{
    public class Atividade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idAtividade { get; set; }
        [Required]
        [MaxLength(30)]
        public string? enunciado { get; set; }
        public string? conteudo { get; set; }
        public string? solucao { get; set; }
        [NotMapped]
        public List<string>? questao { get; set; }
        public Boolean? isFinished { get; set; }

        public int idLicao { get; set; }

        public Licao Licao { get; set; } = null!;

        public Atividade(){}

        public Atividade(AtividadeDTO atividadeDto){
            this.enunciado = atividadeDto.enunciado;
            this.conteudo = atividadeDto.conteudo;
            this.solucao = atividadeDto.solucao;
            this.questao = atividadeDto.questao;
            this.isFinished = atividadeDto.isFinished;
            this.idLicao = atividadeDto.idLicao;
        }
        // public Licao(){
        //     this.Usuarios = new HashSet<Usuario>();
        // }
    }
}