using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NatureBlog.Domain.Models;

namespace NatureBlog.Infrastructure.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> userBuilder)
        {

            userBuilder.ToTable(nameof(User));
            userBuilder.HasKey(x => x.Id);

            userBuilder.Property<string>(x => x.Username)
                .IsRequired()
                .HasMaxLength(50);

            userBuilder.Property<string>(x => x.Email)
                .IsRequired()
                .HasMaxLength(161);

            userBuilder.HasMany(u => u.VisitedDestinations)
                .WithMany(d => d.Visitors);
        }
    }
}
