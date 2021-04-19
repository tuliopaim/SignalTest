using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignalTest.Application.Services.Interfaces;
using SignalTest.Domain.DTOs;
using SignalTest.Domain.Entities;
using SignalTest.Domain.Interfaces.Notification;
using SignalTest.Domain.Interfaces.Repository;

namespace SignalTest.Application.Services
{
    public class TweetService : ITweetService
    {
        private readonly ITweetRepository _repository;
        private readonly ITweetNotificationService _notification;

        public TweetService(ITweetRepository repository,
            ITweetNotificationService notification)
        {
            _repository = repository;
            _notification = notification;
        }

        public async Task<TweetDto> ObterPorId(Guid id)
        {
            var tweet = await _repository.ObterPorId(id);

            return ConverterParaViewModel(tweet);
        }

        public async Task<IEnumerable<TweetDto>> ObterTodos()
        {
            var tweets = await _repository.ObterTodos();

            tweets ??= new List<Tweet>();

            return tweets.Select(ConverterParaViewModel);
        }

        public async Task NovoTweet(string mensagem, Guid userId)
        {
            var tweet = new Tweet(userId, mensagem);

            await _repository.Add(tweet);

            var tweetFinal = await _repository.ObterPorId(tweet.Id);

            var tweetDto = ConverterParaViewModel(tweetFinal);

            await _notification.NotificarNovoTweet(tweetDto);
        }

        private static TweetDto ConverterParaViewModel(Tweet tweet)
        {
            if (tweet is null) return null;

            return new TweetDto
            {
                Id = tweet.Id,
                Mensagem = tweet.Mensagem,
                Data = tweet.Data,
                NomeUsuario = tweet.User?.Nome,
            };
        }
    }
}