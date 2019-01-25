using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TestTask.Helpers;

namespace TestTask.Models
{
    public enum UserRolesEnum
    {
        User,
        Manager,
        Support,
        Admin
    }

    public class User
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [Index(IsUnique = true)]
        public string SkypeLogin { get; set; }

        public string Signature { get; set; }

        public string Avatar { get; set; }

        [DefaultRole(UserRolesEnum.User)]
        public UserRolesEnum Role { get; set; }

        public bool? IsDisabled { get; set; }
    }
}