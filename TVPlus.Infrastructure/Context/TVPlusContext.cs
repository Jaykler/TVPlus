
using Microsoft.EntityFrameworkCore;
using TVPlus.Domain.Entities;


namespace TVPlus.Infrastructure.Context
{
    public class TVPlusContext : DbContext
    {
        
        public TVPlusContext(DbContextOptions<TVPlusContext> options) : base(options) 
        { 
        
        }

        public DbSet<Serie>? Series {  get; set; }
        public DbSet<Productora>? Productoras { get; set; }
        public DbSet<Genero>? Generos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(@"Server=HILDAS-LAPTOP;Database=TVPlusContext;Trusted_Connection=True; TrustServerCertificate=True;");
        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region tables
            modelBuilder.Entity<Serie>()
                .ToTable("Series");
            modelBuilder.Entity<Productora>()
                .ToTable("Productoras");
            modelBuilder.Entity<Genero>()
                .ToTable("Generos");

            #endregion

            #region"Primary Keys"
            modelBuilder.Entity<Serie>()
                .HasKey(s => s.Id);
            modelBuilder.Entity<Productora>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Genero>()
                .HasKey(g => g.Id);
            #endregion

            #region "Relationships"
            modelBuilder.Entity<Serie>()
                .HasMany<Productora>(p => p.Generos);

            #endregion
            /*base.OnModelCreating(modelBuilder);
        }*/
    }
}
