using MediatR;

namespace NatureBlog.Application.App.Destinations.Parks.Commands.UpdateIsDogFriendly
{
    public class IsDogFriendlyCommand : IRequest<bool?>
    {
        public int DestinationId { get; set; }

        public int UserId { get; set; }

        public bool IsDogFriendly { get; set; }
    }
}
