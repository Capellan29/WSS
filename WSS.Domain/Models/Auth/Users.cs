using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSS.Domain.Models.Auth
{
    //Reemplazar por tablas de usuarios cuando se complete la migracion
    [Table("Users")]
    public partial class Users
    {
        [Key]
        public int UserId { get; set; }
        public string User { get; set; }
        public string Passowrd { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public string UpdatedBy { get; set; }
        public bool State { get; set; }

        [NotMapped]
        public string roleNombre { get; set; }
        public virtual UserRole UserRole { get; set; }
    }
}
