using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SignalTest.Domain.Entities;

namespace SignalTest.Domain.Interfaces.Repository
{
    public interface ITweetRepository
    {
        Task<IEnumerable<Tweet>> ObterTodos();
        Task Add(Tweet tweet);
        Task<Tweet> ObterPorId(Guid id);
    }
}