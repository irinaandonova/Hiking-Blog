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
            List<Comment> result = _unitOfWork.DestinationRepository.GetComments(command.Id);
            if (result.Count == 0)
                return Task.FromResult(new List<CommentGetDto> { });

            List<CommentGetDto> mappedResult = _mapper.Map<List<CommentGetDto>>(result);

            return Task.FromResult(mappedResult);
        }
    }
}
