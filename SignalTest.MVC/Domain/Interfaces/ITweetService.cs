using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SignalTest.MVC.DTOs;

namespace SignalTest.MVC.Domain.Interfaces
{
    public interface ITweetService
    {
        Task<TweetDto> ObterPorId(Guid id);
        Task<IEnumerable<TweetDto>> ObterTodos();
        Task<TweetDto> Add(string mensagem, Guid userId);
    }
}