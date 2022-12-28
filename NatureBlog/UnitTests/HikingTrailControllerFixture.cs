using MediatR;
using Moq;
using NatureBlog.Application.Destinations.HikingTrails.Commands.CreateHikingTrail;
using NatureBlog.Domain.Models;
using NatureBlog.Presenatation.Controllers;

namespace UnitTests
{
    internal class HikingTrailControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();

        public async Task Create_Hiking_Trail()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<CreateHikingTrailCommand>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new HikingTrailController(_mockMediator.Object);
            //await controller.CreateHikingTrail()
        }
    }
}
