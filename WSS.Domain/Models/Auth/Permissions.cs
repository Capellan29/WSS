using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WSS.Domain.Models.Auth
{
    public class Permissions
    {
        [Key]
        public int PermissionId { get; set; }
        public string Name { get; set; }
    }
}
