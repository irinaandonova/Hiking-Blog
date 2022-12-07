using Microsoft.EntityFrameworkCore;
using NatureBlog.Domain.Models;
using NatureBlog.Infrastructure.EntityConfiguration;
using System.Reflection;
//Add configurations
namespace NatureBlog.Infrastructure.AppDBContext
{
    public class AppDBContext : DbContext
    {
        private const string ConnectionString = @"Server=DESKTOP-UMPKKH0\SQLEXPRESS;Database=NatureBlog;Encrypt=False;Trusted_Connection=True;";

        public DbSet<Destination> Destinations => Set<Destination>();

        public DbSet<Comment> Comments => Set<Comment>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
