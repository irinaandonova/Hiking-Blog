using MediatR;
using NatureBlog.Domain.Models;

namespace Application.App.Destinations.Parks.Commands.UpdatePark
{
    public class UpdateParkCommand : IRequest<bool>
    {
        public readonly Guid Id;

        public readonly Park park;

        public Guid user;
    }
}
