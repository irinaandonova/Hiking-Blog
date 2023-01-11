using MediatR;
using NatureBlog.Application.Dto.Destination.Park;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.Parks.Queries.GetAllPark
{
    public class GetAllParksQuery : IRequest<List<ParkGetDto>>
    {
        public int Page { get; set; }
    }
}
