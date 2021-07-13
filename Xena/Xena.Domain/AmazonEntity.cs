using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xena.Domain
{
    public class AmazonEntity
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public string Data { get; set; }
        public DateTime LastSyncDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
