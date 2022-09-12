using DesafioClimaTempo.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace DesafioClimaTempo.Domain.Context
{
    public class EFContext : DbContext
    {
        /// <summary>
        /// connectionString
        /// </summary>
        private const string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=ClimaTempoSimples;";

        /// <summary>
        /// Cidades
        /// </summary>
        public virtual DbSet<Cidade> Cidades { get; set; }

        /// <summary>
        /// Estados
        /// </summary>
        public virtual DbSet<Estado> Estados { get; set; }

        /// <summary>
        /// Previsao Clima
        /// </summary>
        public virtual DbSet<PrevisaoClima> PrevisaoClima { get; set; }

        /// <summary>
        /// On Configuring
        /// </summary>
        /// <param name="optionsBuilder">DbContextOptionsBuilder</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        /// <summary>
        /// On Model Creating
        /// </summary>
        /// <param name="modelBuilder">ModelBuilder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cidade>(b =>
            {
                b.ToTable("Cidade");

                b.HasKey(p => p.Id);

                b.HasOne(q => q.Estado)
                .WithMany()
                .HasForeignKey(q => q.EstadoId)
                .OnDelete(deleteBehavior: DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<PrevisaoClima>(b =>
            {
                b.ToTable("Previsao Clima");

                b.HasKey(p => p.Id);
 

                b.HasOne(q => q.Cidade)
                .WithMany()
                .HasForeignKey(q => q.CidadeId)
                .OnDelete(deleteBehavior: DeleteBehavior.NoAction);
            });
        }
    }
}