using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NatureBlog.Domain.Models;

namespace NatureBlog.Infrastructure.EntityConfiguration
{
    public class RatingConfiguration: IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable(nameof(Rating));

            entityTypeBuilder.HasKey(x => x.UserId);

            entityTypeBuilder.Property<int>(x => x.RatingValue)
                .IsRequired();
        }
    }
}
