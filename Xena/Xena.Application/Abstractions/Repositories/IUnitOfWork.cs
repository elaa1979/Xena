using System.Threading.Tasks;
using Xena.Domain.Users;

namespace Xena.Application.Abstractions.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<T> GetReposiotory<T>() where T : class;
        Task<int> CompleteAsync();
    }
}