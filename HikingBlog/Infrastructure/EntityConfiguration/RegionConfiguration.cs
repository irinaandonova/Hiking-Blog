using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NatureBlog.Domain.Models;

namespace NatureBlog.Infrastructure.EntityConfiguration
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> regionBuilder)
        {
            regionBuilder.HasKey(x => x.Id);

            regionBuilder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(60);

            regionBuilder.Property(x => x.Cordinates)
                .IsRequired()
                .HasMaxLength(60);

            regionBuilder.HasMany(x => x.Destinations)
                .WithOne(x => x.Region);
        }
    }
}
