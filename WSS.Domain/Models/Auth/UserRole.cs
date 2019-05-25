using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WSS.Domain.Models.Auth
{
    public class UserRole
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public virtual Users User { get; set; }
        public virtual Roles Role { get; set; }
    }
}