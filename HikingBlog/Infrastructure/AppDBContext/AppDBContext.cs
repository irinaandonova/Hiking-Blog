using Microsoft.EntityFrameworkCore;
using NatureBlog.Domain.Models;
using System.Reflection;
//Add configurations
namespace NatureBlog.Infrastructure
{
    public class AppDBContext : DbContext
    {
        private const string ConnectionString = @"Server=DESKTOP-UMPKKH0\SQLEXPRESS;Database=NatureBlog;Encrypt=False;Trusted_Connection=True;";

        public DbSet<Destination> Destinations => Set<Destination>();

        public DbSet<Comment> Comments => Set<Comment>();

        public DbSet<Region> Regions => Set<Region>();

        public DbSet<User> Users => Set<User>();

        public DbSet<HikingTrail> HikingTrails => Set<HikingTrail>();

        public DbSet<Seaside> Seasides => Set<Seaside>();

        public DbSet<Park> Parks => Set<Park>();

        //public DbSet<UserVisitedDestinations> UserVisitedDestinations => Set<UserVisitedDestinations>();
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
            optionsBuilder.EnableDetailedErrors();
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
