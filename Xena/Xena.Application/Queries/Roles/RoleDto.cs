using System.Collections.Generic;

namespace Xena.Application.Queries.Roles
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<PermissionDto> Permissions { get; set; }
    }
}