using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WSS.Domain.Models.Auth
{
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
        [NotMapped]
        public List<int> Permissions { get; set; }
    }
}