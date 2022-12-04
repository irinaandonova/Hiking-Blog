using MediatR;

namespace NatureBlog.Application.Destinations.HikingTrails.Commands.ChangeDifficulty
{
    public class ChangeDifficultyCommand : IRequest<bool>
    {
        public Guid destinationId;

        public int difficulty;

        public Guid userId;
    }
}
