using MediatR;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.Parks.Commands.UpdatePark
{
    public class UpdateParkCommand : IRequest<bool>
    {
        public Guid Id { get; }

        public Park park { get; set; }

        public Guid user { get; }
    }
}
