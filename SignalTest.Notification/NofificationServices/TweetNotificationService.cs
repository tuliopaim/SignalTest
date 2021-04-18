using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalTest.Domain.Interfaces.Notification;
using SignalTest.Infra.Notification.Hub;
using SignalTest.Infra.Notification.Interfaces;

namespace SignalTest.Infra.Notification.NofificationServices
{
    public class TweetNotificationService : ITweetNotificationService
    {
        private readonly IHubContext<TweetHub, ITweetHub> _hub;

        public TweetNotificationService(IHubContext<TweetHub, ITweetHub> hub)
        {
            _hub = hub;
        }

        public async Task NotificarNovoTweet(string tweet)
        {
            await _hub.Clients.All.NovoTweet(tweet);
        }
    }
}