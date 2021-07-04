using Xena.Domain.Users;

namespace Xena.Domain.Logs
{
    public class Log : BaseEntity
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public int Type { get; set; }
        public int ModuleId { get; set; }
        public string Data { get; set; }
    }
}