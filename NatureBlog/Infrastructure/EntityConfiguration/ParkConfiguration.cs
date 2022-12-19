using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NatureBlog.Domain.Models;

namespace NatureBlog.Infrastructure.EntityConfiguration
{
    public class ParkConfiguration : IEntityTypeConfiguration<Park>
    {
        public void Configure(EntityTypeBuilder<Park> parkBuilder)
        {
            parkBuilder.ToTable(nameof(Park));

            parkBuilder.HasBaseType<Destination>();

            parkBuilder.Property<bool>(x => x.IsDogFriendly)
                .IsRequired();

            parkBuilder.Property<bool>(x => x.HasPlayground)
                .IsRequired();

        }
    }
}
