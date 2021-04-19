using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SignalTest.Domain.Entities;
using SignalTest.Domain.Interfaces.Repository;

namespace SignalTest.Infra.Data.Repository
{
    public class TweetRepository : ITweetRepository
    {
        private readonly ApplicationContext _context;

        public TweetRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Tweet> ObterPorId(Guid id)
        {
            return await _context.Tweets
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        
        public async Task<IEnumerable<Tweet>> ObterTodos()
        {
            return await _context.Tweets
                .Include(x => x.User)
                .OrderByDescending(x => x.Data)
                .ToListAsync();
        }

        public async Task Add(Tweet tweet)
        {
            _context.Tweets.Add(tweet);

            await _context.SaveChangesAsync();
        }
    }
}
