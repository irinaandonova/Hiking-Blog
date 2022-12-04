using MediatR;

namespace NatureBlog.Application.Destinations.HikingTrails.Commands.ChangeDifficulty
{
    public class ChangeDifficultyCommand : IRequest<bool>
    {
        public Guid destinationId { get; }

        public int difficulty { get; set; }

        public Guid userId { get; }
    }
}
