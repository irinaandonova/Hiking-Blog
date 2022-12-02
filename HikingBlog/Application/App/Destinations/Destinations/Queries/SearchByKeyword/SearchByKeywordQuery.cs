using MediatR;
using NatureBlog.Domain.Models;

namespace Application.App.Destinations.Destinations.Queries.SearchByKeyword
{
    public class SearchByKeywordQuery : IRequest<List<Destination>>
    {
        public string keyword;
    }
}
