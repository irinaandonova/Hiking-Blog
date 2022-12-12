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

            destinationConfiguration.HasKey(x => x.Id);

            destinationConfiguration.Property<string>(x => x.Name)
                 .IsRequired()
                 .HasMaxLength(60);

            destinationConfiguration.Property<string>(x => x.Description)
                .IsRequired()
                .HasMaxLength(560);

            destinationConfiguration.Property<string>(x => x.ImageUrl)
                .IsRequired()
                .HasMaxLength(500);

            destinationConfiguration.HasOne(x => x.Creator);

            destinationConfiguration.HasOne(x => x.Region)
                .WithMany(x => x.Destinations)
                .HasForeignKey(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);

            destinationConfiguration.HasMany(x => x.Comments)
                .WithOne(x => x.Destination)
                .HasForeignKey(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
