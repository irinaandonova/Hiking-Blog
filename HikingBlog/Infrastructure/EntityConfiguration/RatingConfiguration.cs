using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NatureBlog.Domain.Models;

namespace NatureBlog.Infrastructure.EntityConfiguration
{
    public class RatingConfiguration: IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> ratingBuilder)
        {
            ratingBuilder.ToTable(nameof(Rating));

            ratingBuilder.HasKey(x => x.Id);

            ratingBuilder.Property<int>(x => x.RatingValue)
                .IsRequired();

        }
    }
}
