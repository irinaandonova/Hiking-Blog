using MediatR;
using NatureBlog.Application.Dto.Destination.Destination;

namespace NatureBlog.Application.App.Destinations.Destinations.Queries.GetDestinationCount
{
    public class GetDestinationCountQuery: IRequest<int?>
    {
        public string Type { get; set; }
    }
}
