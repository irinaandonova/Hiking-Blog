using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NatureBlog.Domain.Models;

namespace NatureBlog.Infrastructure.EntityConfiguration
{
    public class HikingTrailConfuguration : IEntityTypeConfiguration<HikingTrail>
    {
        public void Configure(EntityTypeBuilder<HikingTrail> hikingTrailBuiler)
        {
            hikingTrailBuiler.ToTable(nameof(HikingTrail));

            hikingTrailBuiler.HasBaseType<Destination>();

            hikingTrailBuiler.Property<int>(x => x.HikingDuration)
                .IsRequired();                

            hikingTrailBuiler.Property<int>(x => x.Difficulty)
                .IsRequired();
        }
    }
}
