using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignalTest.MVC.Domain.Entities;
using SignalTest.MVC.Domain.Interfaces;
using SignalTest.MVC.DTOs;

namespace SignalTest.MVC.Services
{
    public class TweetService : ITweetService
    {
        private readonly ITweetRepository _repository;

        public TweetService(ITweetRepository repository)
        {
            _repository = repository;
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

        public async Task<TweetDto> Add(string mensagem, Guid userId)
        {
            var tweet = new Tweet(userId, mensagem);

            await _repository.Add(tweet);

            return ConverterParaViewModel(tweet);
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