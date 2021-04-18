using System.Threading.Tasks;

namespace SignalTest.Domain.Interfaces.Notification
{
    public interface ITweetNotificationService
    {
        Task NotificarNovoTweet(string tweet);
    }
}