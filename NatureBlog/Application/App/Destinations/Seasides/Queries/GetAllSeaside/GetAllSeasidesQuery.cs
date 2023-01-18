using MediatR;
using NatureBlog.Application.Dto.Destination.Destination;

namespace NatureBlog.Application.Destinations.Seasides.Queries.GetAllSeaside
{
    public class GetAllSeasidesQuery : IRequest<List<DestinationGetDto?>>
    {
        public int Page { get; set; }

        public string Sorting { get; set; }
    }
}
