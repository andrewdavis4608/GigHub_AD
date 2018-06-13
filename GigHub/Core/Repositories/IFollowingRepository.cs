using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
    public interface IFollowingRepository
    {
        Following GetFollowing(string followerId, string userId);
        void Add(Following following);
        void Remove(Following following);
    }
}