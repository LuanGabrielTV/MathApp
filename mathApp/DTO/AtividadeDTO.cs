
namespace mathApp.DTO
{
    public class AtividadeDTO
    {
        public string? enunciado { get; set; }
        public string? conteudo { get; set; }
        public string? solucao { get; set; }
        public List<string>? questao { get; set; }
        public Boolean? isFinished { get; set; }

        public int idLicao { get; set; }


        // public Licao(){
        //     this.Usuarios = new HashSet<Usuario>();
        // }
    }
}