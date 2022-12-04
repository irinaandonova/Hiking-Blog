using Application.Repositories;
using MediatR;
using NatureBlog.Application.Destinations.HikingTrails.Commands.CreateHikingTrail;
using NatureBlog.Application.Destinations.Interfaces;
using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.App.Comments.Commands.CreateComment
{
    public class CreateCommentHandler : IRequestHandler<CreateCommentCommand, bool>
    {
        private readonly ICommentRepository _repository;

        public CreateCommentHandler(ICommentRepository commentRepository)
        {

            _repository = commentRepository;
        }

        public Task<bool> Handle(CreateCommentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                bool response = _repository.CreateComment(command.destinationId, command.creatorId, command.text);

                if (response)
                    return Task.FromResult(true);
                else
                    throw new ModificationFailedException("Creating a comment was unsuccessful!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in CreateComment Method" + ex.Message);
                return Task.FromResult(false);
            }
        }
    }
}
