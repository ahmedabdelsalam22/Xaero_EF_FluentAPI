using EF_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Xaero_EF.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ProductionCompany> ProductionCompany { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<MovieDetail> MovieDetail { get; set; }
        public DbSet<Distribution> Distribution { get; set; }
        public DbSet<MovieDistribution> MovieDistribution { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // ProductionCompany
            modelBuilder.Entity<ProductionCompany>().HasKey(x => x.Id);

            modelBuilder.Entity<ProductionCompany>(entity =>
            {
                entity.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(x => x.Logo)
                .IsRequired();

                entity.Property(x => x.AnnualReveune)
                .IsRequired()
                .HasColumnType("Money");

                entity.Property(x => x.EstablishmentDate)
                .IsRequired()
                .HasColumnType("Date");
            });

            // Movie
            modelBuilder.Entity<Movie>().HasKey(x => x.Id);

            modelBuilder.Entity<Movie>()
                .HasOne(x => x.ProductionCompany)
                .WithMany(X => X.Movies)
                .HasForeignKey(x => x.ProductionCompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            // MovieDetail
            modelBuilder.Entity<MovieDetail>().HasKey(x => x.MovieId);

            modelBuilder.Entity<MovieDetail>(entity =>
            {
                entity.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(x => x.Poster)
                .IsRequired();

                entity.Property(x => x.Budget)
                .IsRequired()
                .HasColumnType("Money");

                entity.Property(x => x.Gross)
                .IsRequired();

                entity.Property(e => e.ReleaseDate)
                    .IsRequired()
                    .HasColumnType("Date");
            });

            // Distribution
            modelBuilder.Entity<Distribution>().HasKey(s => s.Id);
            modelBuilder.Entity<Distribution>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Location)
                    .IsRequired();

                entity.Property(e => e.TelePhone)
                    .IsRequired();
            });


            // MovieDistribution
            modelBuilder.Entity<MovieDistribution>().HasKey(x => new { x.MovieId, x.DistributionId });

            modelBuilder.Entity<MovieDistribution>()
                .HasOne(x => x.Movies)
                .WithMany(x => x.MovieDistribution)
                .HasForeignKey(x => x.MovieId);

            modelBuilder.Entity<MovieDistribution>()
                .HasOne(x => x.Distributions)
                .WithMany(x => x.MovieDistribution)
                .HasForeignKey(x => x.DistributionId);


            base.OnModelCreating(modelBuilder);


        }



    }
}
