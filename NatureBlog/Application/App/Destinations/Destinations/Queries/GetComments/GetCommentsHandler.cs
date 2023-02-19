using AutoMapper;
using MediatR;
using NatureBlog.Application.Dto.Comment;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.App.Destinations.Destinations.Queries.GetComments
{
    public class GetCommentsHandler : IRequestHandler<GetCommentsQuery, List<CommentGetDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCommentsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<List<CommentGetDto>> Handle(GetCommentsQuery command, CancellationToken cancellationToken)
        {
            try
            {
                List<Comment> result = _unitOfWork.CommentRepository.GetComments(command.Id);
                if (result.Count == 0)
                    return Task.FromResult(new List<CommentGetDto> { });

                List<CommentGetDto> mappedResult = _mapper.Map<List<CommentGetDto>>(result);

                foreach (var comment in mappedResult)
                {
                    User user = _unitOfWork.UserRepository.GetUser(comment.CreatorId);
                    comment.Username = user.Username;
                }

                return Task.FromResult(mappedResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the Get Comments method", ex.Message);
                throw ex;
            }
        }
    }
}
