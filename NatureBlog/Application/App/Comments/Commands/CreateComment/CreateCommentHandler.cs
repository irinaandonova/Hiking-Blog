using AutoMapper;
using MediatR;
using NatureBlog.Application.Dto.Comment;
using NatureBlog.Application.Exceptions;
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
                User user = _unitOfWork.UserRepository.GetUser(command.CreatorId);
                if (user is null)
                    throw new UserNotFoundException("No user with this id found!");

                Comment comment = new Comment { DestinationId = command.DestinationId, CreatorId = command.CreatorId, Text = command.Text, Date = DateTime.Now };
                _unitOfWork.CommentRepository.CreateComment(comment);

                var destination = _unitOfWork.DestinationRepository.GetDestination(comment.DestinationId);
                if (destination is null)
                    throw new DestinationNotFoundException("No destination with this id found"!);

                destination.Comments.Add(comment);
                await _unitOfWork.Save();

                if (comment is not null)
                {
                    var mappedResult = _mapper.Map<CommentGetDto>(comment);
                    mappedResult.Username = user.Username;
                    return mappedResult;
                }

                else
                    return null;
            }
            catch(UserNotFoundException ex)
            {
                throw ex;
            }
            catch(DestinationNotFoundException ex)
            {
                throw ex;
            }
            catch(CommentModificationFailedException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in CreateComment Method" + ex.Message);
                return null;
            }
        }
    }
}
