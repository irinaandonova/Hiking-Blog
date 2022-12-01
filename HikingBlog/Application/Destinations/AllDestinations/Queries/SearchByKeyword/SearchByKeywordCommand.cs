using MediatR;
using NatureBlog.Domain.Models;

namespace NatureBlog. Application.Destinations.AllDestinations.Queries.SearchByKeyword
{
    public class SearchByKeywordCommand : IRequest<List<Destination>>
    {
        public string keyword;
    }
}
