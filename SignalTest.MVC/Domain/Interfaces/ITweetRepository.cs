using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SignalTest.MVC.Domain.Entities;

namespace SignalTest.MVC.Domain.Interfaces
{
    public interface ITweetRepository
    {
        Task<IEnumerable<Tweet>> ObterTodos();
        Task Add(Tweet tweet);
        Task<Tweet> ObterPorId(Guid id);
    }
}