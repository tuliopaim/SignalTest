using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalTest.Domain.DTOs;
using SignalTest.Domain.Interfaces.Notification;
using SignalTest.Infra.Notification.Hubs;
using SignalTest.Infra.Notification.Interfaces;

namespace SignalTest.Infra.Notification.NotificationServices
{
    public class TweetNotificationService : ITweetNotificationService
    {
        private readonly IHubContext<TweetHub, ITweetHub> _hub;

        public TweetNotificationService(IHubContext<TweetHub, ITweetHub> hub)
        {
            _hub = hub;
        }

        public async Task NotificarNovoTweet(TweetDto tweet)
        {
            await _hub.Clients.All.NovoTweet(tweet);
        }
    }
}