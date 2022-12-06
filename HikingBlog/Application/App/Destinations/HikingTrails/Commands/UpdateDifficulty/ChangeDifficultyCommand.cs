using MediatR;

namespace NatureBlog.Application.Destinations.HikingTrails.Commands.ChangeDifficulty
{
    public class ChangeDifficultyCommand : IRequest<bool>
    {
        public Guid DestinationId { get; set; }

        public int Difficulty { get; set; }

        public Guid UserId { get; set; }
    }
}
