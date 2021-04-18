using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalTest.Notification.Hub;
using SignalTest.Notification.Interfaces;

namespace SignalTest.Notification.NofificationServices
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