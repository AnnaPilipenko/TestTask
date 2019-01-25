using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public string SkypeLogin { get; set; }

        public string Signature { get; set; }

        public string Avatar { get; set; }

        [DefaultRole(UserRolesEnum.User)]
        public UserRolesEnum Role { get; set; }

        public bool? IsDisabled { get; set; }
    }
}