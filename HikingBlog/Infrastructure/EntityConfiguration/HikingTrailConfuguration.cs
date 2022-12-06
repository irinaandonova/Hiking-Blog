using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NatureBlog.Domain.Models;

namespace NatureBlog.Infrastructure.EntityConfiguration
{
    public class HikingTrailConfuguration : IEntityTypeConfiguration<HikingTrail>
    {
        public void Configure(EntityTypeBuilder<HikingTrail> hikingTrailBuiler)
        {
            hikingTrailBuiler.HasKey(x => x.Id);

            hikingTrailBuiler.Property(x => x.HikingDuration)
                .IsRequired();                

            hikingTrailBuiler.Property(x => x.Difficulty)
                .IsRequired();

        }
    }
}
