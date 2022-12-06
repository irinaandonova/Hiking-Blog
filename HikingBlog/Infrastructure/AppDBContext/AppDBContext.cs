using Microsoft.EntityFrameworkCore;
using NatureBlog.Domain.Models;

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
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Destination>()
                .HasKey(d => d.Id);

            modelBuilder.Entity<Comment>()
                .HasKey(c => c.Id);
                
        }
        */
    }
}
