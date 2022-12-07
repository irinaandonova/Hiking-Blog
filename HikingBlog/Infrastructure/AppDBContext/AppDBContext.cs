using Microsoft.EntityFrameworkCore;
using NatureBlog.Domain.Models;
using NatureBlog.Infrastructure.EntityConfiguration;

namespace NatureBlog.Infrastructure.AppDBContext
{
    public class AppDBContext : DbContext
    {
        private const string ConnectionString = @"Server=DESKTOP-UMPKKH0\SQLEXPRESS;Database=Nature Blog;Trusted_Connection=True;";

        public DbSet<Destination> Destinations => Set<Destination>();

        // DbSet<Comment> Comments => Set<Comment>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Destination>().ToTable("Destinations");
            modelBuilder.Entity<Comment>().ToTable("Comments");
            modelBuilder.Entity<Region>().ToTable("Regions");
            modelBuilder.Entity<Rating>().ToTable("Ratings");
            modelBuilder.Entity<Seaside>().ToTable("Seasides");
            modelBuilder.Entity<HikingTrail>().ToTable("HikingTrails");
            modelBuilder.Entity<Park>().ToTable("Parks");

            modelBuilder.ApplyConfiguration(new DestinationConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new RegionConfiguration());
            modelBuilder.ApplyConfiguration(new RatingConfiguration());
            modelBuilder.ApplyConfiguration(new SeasideConfiguration());
            modelBuilder.ApplyConfiguration(new HikingTrailConfuguration());
            modelBuilder.ApplyConfiguration(new ParkConfiguration());

        }
    }
}
