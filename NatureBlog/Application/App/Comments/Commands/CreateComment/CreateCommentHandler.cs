using AutoMapper;
using MediatR;
using NatureBlog.Application.Dto.Comment;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.App.Comments.Commands.CreateComment
{
    public class CreateCommentHandler : IRequestHandler<CreateCommentCommand, CommentGetDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCommentHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommentGetDto> Handle(CreateCommentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Comment comment = new Comment { DestinationId = command.DestinationId, CreatorId = command.CreatorId, Text = command.Text, Date = DateTime.Now };

                _unitOfWork.CommentRepository.CreateComment(comment);
                var destination = _unitOfWork.DestinationRepository.GetDestination(comment.DestinationId);

                destination.Comments.Add(comment);
                await _unitOfWork.Save();

                if (comment is not null)
                {
                    var mappedResult = _mapper.Map<CommentGetDto>(comment);
                    return mappedResult;
                }

                else
                    return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in CreateComment Method" + ex.Message);
                return null;
            }
        }
    }
}
