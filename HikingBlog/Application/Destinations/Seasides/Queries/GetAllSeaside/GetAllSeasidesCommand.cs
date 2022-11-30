using MediatR;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.Seasides.Queries.GetAllSeaside
{
    public class GetAllSeasidesCommand : IRequest<List<Seaside>>
    {
    }
}
