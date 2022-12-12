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

            //destinationConfiguration.HasKey(x => x.Id);

            destinationConfiguration.Property(x => x.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            destinationConfiguration.Property(x => x.Name)
                 .IsRequired()
                 .HasMaxLength(60);

            destinationConfiguration.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(560);

            destinationConfiguration.Property(x => x.ImageUrl)
                .IsRequired()
                .HasMaxLength(500);

            destinationConfiguration.HasOne(x => x.Creator)
                .WithMany(u => u.CreatedDestinations)
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.NoAction);

            destinationConfiguration.HasOne(x => x.Region)
                .WithMany(x => x.Destinations)
                .HasForeignKey(x => x.RegionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
