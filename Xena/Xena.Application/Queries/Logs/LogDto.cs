using Xena.Application.Common.Models;

namespace Xena.Application.Queries.Logs
{
    public class LogDto : BaseDto
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public int Type { get; set; }
        public int ModuleId { get; set; }
        public string Data { get; set; }
    }
}