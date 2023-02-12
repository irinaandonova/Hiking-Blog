using MediatR;
using NatureBlog.Application.Dto.Destination.Destination;

namespace NatureBlog.Application.Destinations.Parks.Queries.GetAllPark
{
    public class GetAllParksQuery : IRequest<List<DestinationGetDto>>
    {
        public int Page { get; set; }

        public string Sorting { get; set; }
    }
}
