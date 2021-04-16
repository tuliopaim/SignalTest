using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SignalTest.MVC.Domain.Entities;
using SignalTest.MVC.Domain.Interfaces;

namespace SignalTest.MVC.Data.Repository
{
    public class UserInstanceRepository : IUserInstanceRepository
    {
        private readonly ApplicationContext _context;

        public UserInstanceRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<UserInstance> ObterPorId(Guid id)
        {
            return await _context.UserInstances.FindAsync(id);
        }

        public async Task<IEnumerable<UserInstance>> ObterTodos()
        {
            return await _context.UserInstances.AsNoTracking().ToListAsync();
        }

        public async Task<int> ObterQuantidadeDesde(DateTime data)
        {
            return await _context.UserInstances
                .Where(x => x.VistoPorUltimo >= data)
                .CountAsync();
        }

        public async Task<IEnumerable<UserInstance>> ObterTodosOnline(DateTime data)
        {
            return await _context.UserInstances
                .Where(x => x.VistoPorUltimo >= data)
                .ToListAsync();
        }

        public async Task Add(UserInstance user)
        {
           await _context.UserInstances.AddAsync(user);

            await _context.SaveChangesAsync();
        }

        public async Task Update(UserInstance user)
        {
            _context.UserInstances.Update(user);

            await _context.SaveChangesAsync();
        }

        public async Task Remove(UserInstance user)
        {
            _context.UserInstances.Remove(user);

            await _context.SaveChangesAsync();
        }
    }
}
