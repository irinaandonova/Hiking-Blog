using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NatureBlog.Application.App.Destinations.HikingTrails.Queries.GetHikingTrailInfo;
using NatureBlog.Application.Destinations.HikingTrails.Commands.CreateHikingTrail;
using NatureBlog.Application.Dto.Destination.HikingTrail;
using NatureBlog.Domain.Models;
using NatureBlog.Presenatation.Controllers;

namespace UnitTests
{
    internal class HikingTrailControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();

        [TestMethod]
        public async Task Create_Hiking_Trail()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<CreateHikingTrailCommand>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new HikingTrailController(_mockMediator.Object);
            //await controller.CreateHikingTrail()
        }

        [TestMethod]
        public async Task Get_Hiking_Trail()
        {
            var hikingTrail = new HikingTrailGetDto
            {
                Id = 1,
                Name = "Perperikon",
                Description = "Rock statues",
                ImageUrl = "image.com",
                RegionId = 1,
                Difficulty = 1,
                Duration = 60
            };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetHikingTrailInfoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(hikingTrail);

            var controller = new HikingTrailController(_mockMediator.Object);
            var result = await controller.GetHikingTrail(1);

            var okResult = result as OkObjectResult;

            Assert.AreEqual(hikingTrail, okResult.Value);
        }
    }
}
