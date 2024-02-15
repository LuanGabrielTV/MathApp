using Microsoft.EntityFrameworkCore;

namespace mathApp.Models
{
    public class MySQLDBContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasMany(u => u.Licoes).WithMany(l => l.Usuarios).UsingEntity("UsuarioHasLicao");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Licao> Licoes { get; set; }
        public MySQLDBContext(DbContextOptions<MySQLDBContext> options) : base(options) { }
    }
}