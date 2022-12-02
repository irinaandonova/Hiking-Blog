using MediatR;
using NatureBlog.Domain.Models;

namespace Application.App.Destinations.Seasides.Queries.GetAllSeaside
{
    public class GetAllSeasidesQuery : IRequest<List<Seaside>>
    {
    }
}
