using MediatR;
using NatureBlog.Application.Dto.Destination.Seaside;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.Seasides.Queries.GetAllSeaside
{
    public class GetAllSeasidesQuery : IRequest<List<SeasideGetDto>>
    {
        public int Page { get; set; }
    }
}
