using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalTest.MVC.Domain.Interfaces;

namespace SignalTest.MVC.Hub
{
    public class TweetHub : Microsoft.AspNetCore.SignalR.Hub
    {
        private readonly ITweetService _service;

        public TweetHub(ITweetService service)
        {
            _service = service;
        }

        public async Task SendTweet(string mensagem)
        {
            if (!Guid.TryParse(Context.UserIdentifier, out var userId)) return;

            var tweet = await _service.Add(mensagem, userId);

            var tweetDto = await _service.ObterPorId(tweet.Id);

            await Clients.All.SendAsync("ReceiveTweet", tweetDto);
        }
    }
}