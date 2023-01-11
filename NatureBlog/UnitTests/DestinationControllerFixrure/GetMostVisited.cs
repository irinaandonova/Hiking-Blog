using MediatR;
using Moq;
using NatureBlog.Application.Destinations.AllDestinations.Queries.GetMostVisited;
using NatureBlog.Application.Dto.Destination.Destination;
using NatureBlog.Presenatation.Controllers;

namespace NatureBlog.UnitTests.DestinationControllerFixrure
{
    [TestClass]
    public class GetMostVisited
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();

      
        /*
        public async Task Get_Most_Visited_Returns_List()
        {
            List<DestinationGetDto> destinationsList= new List<DestinationGetDto>();
            for(int i = 0; i < 10; i++)

            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetMostVisitedQuery>(), It.IsAny<CancellationToken>()))
                .Returns
        }*/
    }
}
