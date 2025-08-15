using lista_presentes.Entities;
using Microsoft.EntityFrameworkCore;

namespace lista_presentes
{
    public class MyDbContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Lista> Lista { get; set; }
        public DbSet<ListaUsuario> ListaUsuario { get; set; }

        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
