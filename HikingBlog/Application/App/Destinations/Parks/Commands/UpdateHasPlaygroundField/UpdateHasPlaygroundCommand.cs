using MediatR;

namespace NatureBlog.Application.App.Destinations.Parks.Commands.UpdateHasPlaygroundField
{
    public class UpdateHasPlaygroundCommand : IRequest<bool>
    {
        public bool HasPlayground { get; set; }

        public Guid DestinationId { get; set; }

        public Guid UserId { get; set; }
    }
}
