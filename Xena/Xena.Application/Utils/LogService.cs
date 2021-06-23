using System;
using System.Threading.Tasks;
using Xena.Application.Abstractions;
using Xena.Application.Abstractions.Repositories;
using Xena.Domain.Logs;
using Newtonsoft.Json;

namespace Xena.Application.Utils
{
    public class LogService : ILogService
    {
        private readonly IUnitOfWork _uow;
        private readonly UserHelper _userHelper;
        public LogService(IUnitOfWork uow, UserHelper userHelper)
        {
            _uow = uow;
            _userHelper = userHelper;
        }

        public async Task LogAsync(int moduleId, int type, object data)
        {
            var repo = _uow.GetReposiotory<Log>();
            var userId = _userHelper.GetUserId();
            var log = new Log
            {
                CreateDate = DateTime.Now,
                Data = JsonConvert.SerializeObject(data),
                ModuleId = moduleId,
                Type = type,
                UserId = userId
            };

            await repo.AddAsync(log);
            await _uow.CompleteAsync();
        }
    }
}