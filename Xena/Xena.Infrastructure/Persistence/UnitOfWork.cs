using System;
using System.Threading.Tasks;
using Xena.Application.Abstractions.Repositories;
using Xena.Domain.Users;
using Xena.Infrastructure.Persistence.Repositories;

namespace Xena.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly XenaContext _context;

        public UnitOfWork(XenaContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IRepository<T> GetReposiotory<T>() where T : class
        {
            return new Repository<T>(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}