using MediatR;
using NatureBlog.Application.Dto.Comment;

namespace NatureBlog.Application.App.Destinations.Destinations.Queries.GetComments
{
    public class GetCommentsQuery : IRequest<List<CommentGetDto>>
    {
        public int Id { get; set; }
    }
}
