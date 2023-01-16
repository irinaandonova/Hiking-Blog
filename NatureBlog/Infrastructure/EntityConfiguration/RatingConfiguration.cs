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

            ratingBuilder.Property(r => r.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();
            
            ratingBuilder.Property(x => x.RatingValue)
                .IsRequired();

            ratingBuilder.HasOne(r => r.Destination)
                .WithMany(d => d.Ratings)
                .HasForeignKey(d => d.DestinationId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
