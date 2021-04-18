using System.Threading.Tasks;
using SignalTest.Domain.DTOs;

namespace SignalTest.Domain.Interfaces.Notification
{
    public interface ITweetNotificationService
    {
        Task NotificarNovoTweet(TweetDto tweet);
    }
}