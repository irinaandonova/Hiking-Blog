using Moq;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.UnitTests
{
    public class MockDestinations
    {
        public static Mock<IDestinationRepository> CreateDestination()
        {
            User user = new User("irina", "irina@andonova", 1);
            Seaside seaside = new Seaside("Konstantin and Elena", System.Guid.NewGuid(), "Amazing beach", "beach.com", "Varna", true, true);
            
            var mockRepo = new Mock<IDestinationRepository>();

            mockRepo.Setup(r => r.Add(seaside)).Returns(true);
            mockRepo.Setup(r => r.Add(null)).Returns(false);

            mockRepo.Setup(r => r.Delete(seaside.Id)).Returns(true);
            mockRepo.Setup(r => r.Delete(user.Id)).Returns(false);  
            mockRepo.Setup(r => r.Delete(System.Guid.Empty)).Returns(false);

            return mockRepo;
        }
    }
}
