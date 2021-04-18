using System.Threading.Tasks;

namespace SignalTest.Notification.Interfaces
{
    public interface ITweetNotificationService
    {
        Task NotificarNovoTweet(string tweet);
    }
}