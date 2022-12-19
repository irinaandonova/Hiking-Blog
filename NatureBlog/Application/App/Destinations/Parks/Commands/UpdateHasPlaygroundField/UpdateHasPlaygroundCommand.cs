using MediatR;

namespace NatureBlog.Application.App.Destinations.Parks.Commands.UpdateHasPlaygroundField
{
    public class UpdateHasPlaygroundCommand : IRequest<bool>
    {
        public bool HasPlayground { get; set; }

        public int DestinationId { get; set; }

        public int UserId { get; set; }
    }
}
