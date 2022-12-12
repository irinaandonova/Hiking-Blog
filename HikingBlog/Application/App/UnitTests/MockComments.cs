using NatureBlog.Application.Repositories;
using Moq;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace Application.App.UnitTests
{
    public class MockComments
    {/*
        public static Mock<ICommentRepository> CreateComment()
        {
            
            var mockRepo = new Mock<ICommentRepository>();

            mockRepo.Setup(r => r.CreateComment(System.Guid.NewGuid(), System.Guid.NewGuid(), "amzaing")).Returns(true);
            mockRepo.Setup(r => r.CreateComment(System.Guid.Empty, System.Guid.NewGuid(), "amzaing")).Returns(false);
            mockRepo.Setup(r => r.CreateComment(System.Guid.NewGuid(), System.Guid.Empty, "amzaing")).Returns(false);
            mockRepo.Setup(r => r.CreateComment(System.Guid.NewGuid(), System.Guid.NewGuid(), "")).Returns(false);

            mockRepo.Setup(r => r.DeleteComment(System.Guid.NewGuid(), System.Guid.NewGuid())).Returns(true);
            mockRepo.Setup(r => r.DeleteComment(System.Guid.Empty, System.Guid.NewGuid())).Returns(false);
            mockRepo.Setup(r => r.DeleteComment(System.Guid.NewGuid(), System.Guid.Empty)).Returns(false);
            mockRepo.Setup(r => r.DeleteComment(System.Guid.Empty, System.Guid.Empty)).Returns(false);
            
            return mockRepo;
        }
    */
    }
}
