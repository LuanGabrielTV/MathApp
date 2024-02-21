
using mathApp.Models;

namespace mathApp.DTO
{
    public class UsuarioDTO
    {
        public int id { get; set; }
        public string nome { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string senha { get; set; } = string.Empty;

        public UsuarioDTO() { }

        public UsuarioDTO(Usuario u)
        {
            this.nome = u.nome;
            this.email = u.email;
            this.id = u.idUsuario;
        }

        public UsuarioDTO(string nome, string email, int id)
        {
            this.nome = nome;
            this.email = email;
            this.id = id;
        }
    }
}