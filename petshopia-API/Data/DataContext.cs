using Microsoft.EntityFrameworkCore;
using petshopia_API.Model;

namespace petshopia_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Dono> Donos { get; set; }
        public DbSet<EstadoSaude> EstadoSaudes { get; set; }
        // public DbSet<EstadoAlojamento> EstadoAlojamentos { get; set; }
        public DbSet<Alojamento> Alojamentos { get; set; }
        public DbSet<Animal> Animais { get; set; }

        // Inicializando tabelas
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<EstadoSaude>().HasData(
                new EstadoSaude (1, "Em tratamento"),
                new EstadoSaude (2, "Em recuperação"),
                new EstadoSaude (3, "Recuperado")
            );

            modelBuilder.Entity<EstadoAlojamento>().HasData(
                new EstadoAlojamento (1, "Livre"),
                new EstadoAlojamento (2, "Ocupado"),
                new EstadoAlojamento (3, "Esperando dono")
            );

            modelBuilder.Entity<Alojamento>().HasData(
                new Alojamento (1, null, 1),
                new Alojamento (2, null, 1),
                new Alojamento (3, null, 1),
                new Alojamento (4, null, 1),
                new Alojamento (5, null, 1),
                new Alojamento (6, null, 1),
                new Alojamento (7, null, 1),
                new Alojamento (8, null, 1),
                new Alojamento (9, null, 1),
                new Alojamento (10, null, 1)
            );

        }

    }
}