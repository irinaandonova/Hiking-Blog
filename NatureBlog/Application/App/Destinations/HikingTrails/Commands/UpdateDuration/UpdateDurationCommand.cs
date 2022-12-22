using MediatR;

namespace NatureBlog.Application.App.Destinations.HikingTrails.Commands.UpdateDuration
{
    public class UpdateDurationCommand: IRequest<bool?>
    {
        public int DestinationId { get; set; }
        
        public int UserId { get; set; }

        public int HikingDuration { get; set; }
    }
}
