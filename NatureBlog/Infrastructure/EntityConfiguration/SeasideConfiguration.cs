using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NatureBlog.Domain.Models;

namespace NatureBlog.Infrastructure.EntityConfiguration
{
    public class SeasideConfiguration : IEntityTypeConfiguration<Seaside>
    {
        public void Configure(EntityTypeBuilder<Seaside> seasideBuilder)
        {
            seasideBuilder.ToTable(nameof(Seaside));

            seasideBuilder.HasBaseType<Destination>();

            seasideBuilder.Property(x => x.OffersUmbrella)
                .IsRequired();

            seasideBuilder.Property(x => x.IsGuarded) 
                .IsRequired();

            seasideBuilder.Property(x => x.UmbrellaPrice);
        }
    }
}
