using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SignalTest.Domain.DTOs;

namespace SignalTest.Application.Services.Interfaces
{
    public interface ITweetService
    {
        Task<TweetDto> ObterPorId(Guid id);
        Task<IEnumerable<TweetDto>> ObterTodos();
        Task NovoTweet(string mensagem, Guid userId);
    }
}