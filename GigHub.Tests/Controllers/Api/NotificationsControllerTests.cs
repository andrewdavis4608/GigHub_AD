using GigHub.Core;
using GigHub.Core.Repositories;
using GigHub.Tests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GigHub.Controllers.Api.Tests
{
    [TestClass()]
    public class NotificationsControllerTests
    {
        private NotificationsController _controller;
        private Mock<INotificationRepository> _mockRepository;
        private string _userId;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepository = new Mock<INotificationRepository>();

            var mockUow = new Mock<IUnitOfWork>();
            mockUow.SetupGet(u => u.Notifications).Returns(_mockRepository.Object);

            _controller = new NotificationsController(mockUow.Object);
            _userId = "1";
            _controller.MockCurrentUser(_userId, "user1@domain.com");
        }

        [TestMethod()]
        public void GetNewNotificationsTest()
        {

        }

        [TestMethod()]
        public void MarksAsReadTest()
        {

        }
    }
}