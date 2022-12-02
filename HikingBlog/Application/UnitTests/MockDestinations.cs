using Moq;
using NatureBlog.Application.Comments.Interfaces;
using NatureBlog.Application.Destinations.Interfaces;
using NatureBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.Application.UnitTests
{
    public class MockDestinations
    {
        public static Mock<IDestinationRepository> CreateDestination()
        {
            User user = new User("irina", "irina@andonova", 1);
            Seaside seaside = new Seaside("Konstantin and Elena", user, "Amazing beach", "beach.com", "Varna", true, true);
            
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
