using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SignalTest.Domain.Entities;
using SignalTest.Domain.Interfaces.Repository;

namespace SignalTest.Infra.Data.Repository
{
    public class UserRepository : IUserInstanceRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<User> ObterPorId(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> ObterTodos()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<User>> ObterTodosOnline(DateTime data)
        {
            return await _context.Users
                .Where(x => x.VistoPorUltimo >= data)
                .ToListAsync();
        }
        
        public async Task Update(User user)
        {
            _context.Users.Update(user);

            await _context.SaveChangesAsync();
        }

        public async Task Remove(User user)
        {
            _context.Users.Remove(user);

            await _context.SaveChangesAsync();
        }
    }
}
