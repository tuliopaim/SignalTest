using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SignalTest.Domain.DTOs;

namespace SignalTest.Domain.Interfaces.Services
{
    public interface ITweetService
    {
        Task<TweetDto> ObterPorId(Guid id);
        Task<IEnumerable<TweetDto>> ObterTodos();
        Task NovoTweet(string mensagem, Guid userId);
    }
}