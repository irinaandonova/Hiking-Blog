using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NatureBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NatureBlog.Domain.Models.Destinations;

namespace NatureBlog.Infrastructure.EntityConfiguration
{
    public class UserVisitedDestinationsConfiguration : IEntityTypeConfiguration<UserVisitedDestinations>
    {
        public void Configure(EntityTypeBuilder<UserVisitedDestinations> visitedDestinationsBuilder)
        {
            visitedDestinationsBuilder.ToTable(nameof(UserVisitedDestinations));
            visitedDestinationsBuilder.HasKey(x => new {x.UserId, x.DestinationId });

            visitedDestinationsBuilder.Property<int>(x => x.UserId)
                .IsRequired();

            visitedDestinationsBuilder.Property<User>(x => x.User)
                .IsRequired();

            visitedDestinationsBuilder.Property<int>(x => x.DestinationId)
                .IsRequired();

            visitedDestinationsBuilder.Property<Destination>(x => x.Destination)
                .IsRequired();
            
            visitedDestinationsBuilder.HasOne(x => x.User)
                .WithMany(x => x.VisitedDestinations)
                .HasForeignKey(x => x.DestinationId);
                //.OnDelete(DeleteBehavior.SetNull);

            visitedDestinationsBuilder.HasOne(x => x.Destination)
                .WithMany(x => x.Visitors)
                .HasForeignKey(x => x.UserId);
                //.OnDelete(DeleteBehavior.SetNull);
        }
    }
}
