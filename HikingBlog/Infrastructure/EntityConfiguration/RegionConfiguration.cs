using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NatureBlog.Domain.Models;

namespace NatureBlog.Infrastructure.EntityConfiguration
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> regionBuilder)
        {
            regionBuilder.ToTable(nameof(Region));

            regionBuilder.HasKey(x => x.Id);

            regionBuilder.Property<string>(x => x.Name)
                .IsRequired()
                .HasMaxLength(60);

            regionBuilder.Property<string>(x => x.Cordinates)
                .IsRequired()
                .HasMaxLength(60);

            regionBuilder.HasMany(x => x.Destinations)
                .WithOne(x => x.Region)
                .HasForeignKey(x => x.Id);
        }
    }
}
