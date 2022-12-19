using MediatR;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.Seasides.Queries.FilterSeaside
{
    public class FilterSeasidesQuery : IRequest<List<Seaside>>
    {
        public bool IsGuarded { get; set; }

        public bool OffersUmbrellas { get; set; }
    }
}
