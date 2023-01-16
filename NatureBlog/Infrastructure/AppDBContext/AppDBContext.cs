using Microsoft.EntityFrameworkCore;
using NatureBlog.Domain.Models;
using System.Reflection;

namespace NatureBlog.Infrastructure
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Destination> Destinations => Set<Destination>();

        public DbSet<Comment> Comments => Set<Comment>();

        public DbSet<Region> Regions => Set<Region>();

        public DbSet<User> Users => Set<User>();

        public DbSet<HikingTrail> HikingTrails => Set<HikingTrail>();

        public DbSet<Seaside> Seasides => Set<Seaside>();

        public DbSet<Park> Parks => Set<Park>();

        public DbSet<Rating> Ratings => Set<Rating>();  

        //public DbSet<UserVisitedDestinations> UserVisitedDestinations => Set<UserVisitedDestinations>();
        
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
