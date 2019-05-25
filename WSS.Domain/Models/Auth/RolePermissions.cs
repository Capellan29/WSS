using System;
using System.Collections.Generic;
using System.Text;

namespace WSS.Domain.Models.Auth
{
    public class RolePermissions
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
        public virtual Permissions Permission { get; set; }
        public virtual Roles Role { get; set; }
    }
}
