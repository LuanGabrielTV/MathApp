using Microsoft.EntityFrameworkCore;

namespace mathApp.Models
{
    public class MySQLDBContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioHasLicao>().HasOne(m => m.Licao).WithMany(l => l.Matriculas);
            modelBuilder.Entity<UsuarioHasLicao>().HasOne(m => m.Usuario).WithMany(u => u.Matriculas);
            modelBuilder.Entity<UsuarioHasLicao>().HasKey(m => new { m.idUsuario, m.idLicao });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Licao> Licoes { get; set; }

        public DbSet<UsuarioHasLicao> Matriculas { get; set; }
        public MySQLDBContext(DbContextOptions<MySQLDBContext> options) : base(options) { }
    }
}