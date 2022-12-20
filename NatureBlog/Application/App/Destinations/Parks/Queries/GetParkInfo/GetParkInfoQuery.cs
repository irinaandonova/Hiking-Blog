using MediatR;
using NatureBlog.Application.Dto.Destination.Park;

namespace NatureBlog.Application.App.Destinations.Parks.Queries.GetParkInfo
{
    public class GetParkInfoQuery : IRequest<ParkGetDto>
    {
        public int Id { get; set; }
    }
}
