using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NatureBlog.Domain.Models;

namespace NatureBlog.Infrastructure.EntityConfiguration
{
    public class SeasideConfiguration : IEntityTypeConfiguration<Seaside>
    {
        public void Configure(EntityTypeBuilder<Seaside> seasideBuilder)
        {
            seasideBuilder.HasKey(x => x.Id);

            seasideBuilder.Property<bool>(x => x.OffersUmbrella)
                .IsRequired();

            seasideBuilder.Property<bool>(x => x.IsGuarded) 
                .IsRequired();

            seasideBuilder.Property<double>(x => x.UmbrellaPrice);
        }
    }
}
