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

            regionBuilder.Property(r => r.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();
                       
            regionBuilder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(60);

            regionBuilder.Property(r => r.Cordinates)
                .IsRequired()
                .HasMaxLength(60);
        }
    }
}
