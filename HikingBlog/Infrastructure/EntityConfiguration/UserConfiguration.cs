using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NatureBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            userBuilder.HasMany(x => x.VisitedDestinations)
                .WithMany(x => x.Visitors);
        }
    }
}
