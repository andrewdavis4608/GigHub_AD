using GigHub.Core.Repositories;

namespace GigHub.Core
{
    public interface IUnitOfWork
    {
        IGigRepository Gigs { get; }
        IGenreRepository Genres { get; }
        IAttendanceRepository Attendances { get; }
        IFollowingRepository Followings { get; }
        IApplicationUserRepository Users { get; }
        INotificationRepository Notifications { get; }
        IUserNotificationRepository UserNotifications { get; }
        void Complete();
    }
}