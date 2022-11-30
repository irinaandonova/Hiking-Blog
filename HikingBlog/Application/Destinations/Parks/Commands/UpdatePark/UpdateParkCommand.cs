using MediatR;
using NatureBlog.Domain.Models;

namespace Application.Destinations.Parks.Commands.UpdatePark
{
    public class UpdateParkCommand : IRequest<bool>
    {
        public readonly Guid Id;

        public readonly Park park;

        public User user;
    }
}
