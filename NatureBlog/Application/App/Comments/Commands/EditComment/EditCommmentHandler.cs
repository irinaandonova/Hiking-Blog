using AutoMapper;
using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.App.Comments.Commands.EditComment
{
    public class EditCommmentHandler : IRequestHandler<EditCommentCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EditCommmentHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(EditCommentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Comment comment = _unitOfWork.CommentRepository.GetComment(command.Id);

                if (comment is null )
                    throw new CommentNotFoundException("No comment with given id found!");

                if (comment.CreatorId != command.UserId)
                    throw new UserNotCreatorException("Current user is not the creator of this comment");

                var result = _unitOfWork.CommentRepository.EditComment(comment, command.Text);
                await _unitOfWork.Save();
                if (!result)
                    throw new CommentModificationFailedException("Comment wasn't successfully modified");

                return true;
            }
            catch(CommentNotFoundException ex)
            {
                throw ex;
            }
            catch (CommentModificationFailedException ex)
            {
                throw ex;
            }
            catch (UserNotCreatorException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Edit Comment Method: ", ex.Message);
                return false;
            }
        }
    }
}
