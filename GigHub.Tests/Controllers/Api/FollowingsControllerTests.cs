using FluentAssertions;
using GigHub.Controllers.Api;
using GigHub.Core;
using GigHub.Core.Dtos;
using GigHub.Core.Models;
using GigHub.Core.Repositories;
using GigHub.Tests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Http.Results;

namespace GigHub.Tests.Controllers.Api
{
    [TestClass]
    public class FollowingsControllerTests
    {
        private FollowingsController _controller;
        private Mock<IFollowingRepository> _mockRepository;
        private string _userId;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepository = new Mock<IFollowingRepository>();
            var mockUow = new Mock<IUnitOfWork>();
            mockUow.SetupGet(u => u.Followings).Returns(_mockRepository.Object);

            _controller = new FollowingsController(mockUow.Object);
            _userId = "1";
            _controller.MockCurrentUser(_userId, "user1@domain.com");
        }

        [TestMethod]
        public void Follow_UserFollowingAnArtistForWhichHeIsFollowing_ShouldReturnBadRequest()
        {
            var following = new Following();
            _mockRepository.Setup(r => r.GetFollowing("1", _userId)).Returns(following);
            var result = _controller.Follow(new FollowingDto { FolloweeId = "1" });
            result.Should().BeOfType<BadRequestErrorMessageResult>();
        }

        [TestMethod]
        public void Follow_ValidRequest_ShouldReturnOk()
        {
            var result = _controller.Follow(new FollowingDto { FolloweeId = "1" });
            result.Should().BeOfType<OkResult>();
        }

        [TestMethod]
        public void Unfollow_NoFollowerWithGivenIdExists_ShouldReturnNotFound()
        {
            var result = _controller.Unfollow("1");
            result.Should().BeOfType<NotFoundResult>();
        }

        [TestMethod]
        public void Unfollow_ValidRequest_ShouldReturnOk()
        {
            var following = new Following();
            _mockRepository.Setup(r => r.GetFollowing("1", _userId)).Returns(following);
            var result = _controller.Unfollow("1");
            result.Should().BeOfType<OkNegotiatedContentResult<string>>();
        }

        [TestMethod]
        public void Unfollow_ValidRequest_ShouldReturnTheIdOfDeletedFollower()
        {
            var following = new Following();
            _mockRepository.Setup(r => r.GetFollowing("1", _userId)).Returns(following);
            var result = (OkNegotiatedContentResult<string>) _controller.Unfollow("1");
            result.Content.Should().Be("1");
        }
    }
}
