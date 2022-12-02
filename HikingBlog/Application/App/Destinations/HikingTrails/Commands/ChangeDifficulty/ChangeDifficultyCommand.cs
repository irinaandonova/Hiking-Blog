using MediatR;

namespace Application.App.Destinations.HikingTrails.Commands.ChangeDifficulty
{
    public class ChangeDifficultyCommand : IRequest<bool>
    {
        public Guid destinationId;

        public int difficulty;

        public Guid userId;
    }
}
