using MediatR;
using Moq;
using NatureBlog.Application.Destinations.AllDestinations.Queries.FilterByRegion;
using NatureBlog.Application.Destinations.AllDestinations.Queries.GetMostVisited;
using NatureBlog.Application.Destinations.AllDestinations.Queries.SearchByKeyword;
using NatureBlog.Presenatation.Controllers;

namespace UnitTests.DestinationControllerFixrure
{
    [TestClass]
    public class DestinationControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();

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
        /*
        [TestMethod]
        public async Task Filter_By_Region_Result()
        {
            List<DestinationGetDto> result = new List<DestinationGetDto>();
            _mockMediator
                .Setup(m => m.Send(It.IsAny<FilterByRegionQuerry>(), It.IsAny<CancellationToken>()))
                .Returns<FilterByRegionQuerry, CancellationToken>(async (q, ct) =>
                {
                    result = 
                });
        }*/
        [TestMethod]
        public async Task Search_By_String()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<SearchByDestinationNameQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new DestinationController(_mockMediator.Object);
            await controller.SearchByDestinationName("Lauta");

            _mockMediator.Verify(m => m.Send(It.IsAny<SearchByDestinationNameQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}