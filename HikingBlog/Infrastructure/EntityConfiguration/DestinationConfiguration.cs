using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NatureBlog.Domain.Models;
using NatureBLog.Domain.Models.Region;
using System.Security.Cryptography.X509Certificates;

namespace NatureBlog.Infrastructure.EntityConfiguration
{
    public class DestinationConfiguration : IEntityTypeConfiguration<Destination>
    {
        public void Configure(EntityTypeBuilder<Destination> destinationConfiguration)
        {
            destinationConfiguration.HasKey(x => x.Id);

            destinationConfiguration.Property<string>(x => x.Name)
                 .IsRequired()
                 .HasMaxLength(60);
                
            destinationConfiguration.Property<string>(x => x.Description)
                .IsRequired()
                .HasMaxLength(560);

            destinationConfiguration.Property<string>(x => x.ImageUrl)
                .IsRequired()
                .HasMaxLength (500);

            destinationConfiguration.HasOne(x => x.Region)
                .WithMany(x => x.Destinations)
                .HasForeignKey(x => x.Id);
                
            destinationConfiguration.HasMany(x => x.Comments)
                .WithOne(x => x.Destination)
                .HasForeignKey(x => x.Destination.Id);

            destinationConfiguration.HasMany(x => x.Visitors)
                .WithMany(x => x.VisitedDestinations);







        }
    }
}
