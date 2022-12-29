using AutoMapper;
using MediatR;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.App.Comments.Commands.EditComment
{
    public class EditCommmentHandler : IRequestHandler<EditCommentCommand, bool?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EditCommmentHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool?> Handle(EditCommentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Comment comment = _unitOfWork.CommentRepository.GetComment(command.Id);

                if (comment is null || comment.CreatorId != command.UserId)
                    return null;

                var result = _unitOfWork.CommentRepository.EditComment(comment, command.Text);
                await _unitOfWork.Save();

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception in Edit Comment Method: ", ex.Message);
                return false;
            }
        }
    }
}
