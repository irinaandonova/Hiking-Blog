using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NatureBlog.Domain.Models;

namespace NatureBlog.Infrastructure.EntityConfiguration
{
    public class DestinationConfiguration : IEntityTypeConfiguration<Destination>
    {
        public void Configure(EntityTypeBuilder<Destination> destinationConfiguration)
        {
            destinationConfiguration.ToTable(nameof(Destination));

            destinationConfiguration.Property(d => d.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            destinationConfiguration.Property(d => d.Name)
                 .IsRequired()
                 .HasMaxLength(60);

            destinationConfiguration.Property(d => d.Description)
                .IsRequired()
                .HasMaxLength(560);

            destinationConfiguration.Property(d => d.ImageUrl)
                .IsRequired()
                .HasMaxLength(500);

            destinationConfiguration.HasOne(d => d.Creator)
                .WithMany(u => u.CreatedDestinations)
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.NoAction);

            destinationConfiguration.HasOne(d => d.Region)
                .WithMany(d => d.Destinations)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
