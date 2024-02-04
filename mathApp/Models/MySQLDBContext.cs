using Microsoft.EntityFrameworkCore;

namespace mathApp.Models
{
    public class MySQLDBContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioHasLicao>().HasKey(ul => new { ul.idUsuario, ul.idLicao });
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Licao> Licoes { get; set; }
        public DbSet<UsuarioHasLicao> MatriculasLicoes { get; set; }
        public MySQLDBContext(DbContextOptions<MySQLDBContext> options) : base(options) { }
    }
}