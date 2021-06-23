using System.Threading.Tasks;

namespace Xena.Application.Abstractions
{
    public interface  ILogService
    {
        Task LogAsync(int moduleId, int type, object data);
    }
}