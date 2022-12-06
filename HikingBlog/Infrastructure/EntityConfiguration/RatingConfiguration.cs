using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NatureBlog.Domain.Models;

namespace NatureBlog.Infrastructure.EntityConfiguration
{
    public class RatingConfiguration: IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.User);

            entityTypeBuilder.Property(x => x.User)
                .IsRequired();

            entityTypeBuilder.Property(x => x.RatingValue)
                .IsRequired();

        }
    }
}
