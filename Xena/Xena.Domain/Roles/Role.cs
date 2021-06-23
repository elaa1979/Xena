using System.Collections.Generic;

namespace Xena.Domain.Roles
{
    public class Role
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<RolePermission> Persmissions { get; set; }
    }
}