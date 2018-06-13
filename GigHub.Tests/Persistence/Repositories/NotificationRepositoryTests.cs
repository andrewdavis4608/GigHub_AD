using GigHub.Core.Models;
using GigHub.Persistence;
using GigHub.Persistence.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;

namespace GigHub.Tests.Persistence.Repositories
{
    [TestClass]
    public class NotificationRepositoryTests
    {
        private Mock<DbSet<Notification>> _mockNotifications;
        private NotificationRepository _repository;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockNotifications = new Mock<DbSet<Notification>>();

            var mockContext = new Mock<IApplicationDbContext>();
            mockContext.SetupGet(c => c.Notifications).Returns(_mockNotifications.Object);

            _repository = new NotificationRepository(mockContext.Object);
        }

        [TestMethod]
        public void GetNewNotificationsFor_NotificationIsRead_ShouldNotBeReturned()
        {

        }

        [TestMethod]
        public void GetNewNotificationsFor_NotificationIsForADifferentUser_ShouldNotBeReturned()
        {

        }

        [TestMethod]
        public void GetNewNotificationsFor_NewNotificationForTheGivenUser_ShouldBeReturned()
        {

        }
    }
}
