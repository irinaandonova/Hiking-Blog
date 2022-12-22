using MediatR;
using Moq;
using NatureBlog.Application.Destinations.AllDestinations.Queries.FilterByRegion;
using NatureBlog.Application.Destinations.AllDestinations.Queries.GetMostVisited;
using NatureBlog.Application.Destinations.AllDestinations.Queries.SearchByKeyword;
using NatureBlog.Presenatation.Controllers;

namespace UnitTests
{
    [TestClass]
    public class DestinationControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();

        [TestMethod]
        public async Task Get_Most_Visited()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny <GetMostVisitedQuery>(), It.IsAny < CancellationToken>()))
                .Verifiable();

            var controller = new DestinationController(_mockMediator.Object);
            await controller.GetMostVisited();

            _mockMediator.Verify(m => m.Send(It.IsAny<GetMostVisitedQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task Filter_By_Region()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<FilterByRegionQuerry>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new DestinationController(_mockMediator.Object);
            await controller.FilterByRegion(3);

            _mockMediator.Verify(m => m.Send(It.IsAny<FilterByRegionQuerry>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestMethod]
        public async Task Search_By_String()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<SearchByStringQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new DestinationController(_mockMediator.Object);
            await controller.SearchByString("Plovdiv");

            _mockMediator.Verify(m => m.Send(It.IsAny<SearchByStringQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}