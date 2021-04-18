using System.Threading.Tasks;
using SignalTest.Domain.DTOs;

namespace SignalTest.Infra.Notification.Interfaces
{
    public interface ITweetHub
    {
        Task NovoTweet(TweetDto tweet);
    }
}