using MediatR;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.Seasides.Commands.UpdateSeaside
{
    public class UpdateSeasideCommand : IRequest<bool>
    {
        public Guid Id { get; }

        public Seaside seaside { get; set; }

        public Guid user { get; }
    }
}
