using MediatR;

namespace NatureBlog.Application.Destinations.HikingTrails.Commands.ChangeDifficulty
{
    public class ChangeDifficultyCommand : IRequest<bool>
    {
        public int DestinationId { get; set; }

        public int Difficulty { get; set; }

        public int UserId { get; set; }
    }
}
