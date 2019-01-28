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
        /// <summary>
        /// Unique Id of user
        /// </summary>
        [Required]
        public long Id { get; set; }

        /// <summary>
        /// Name of user
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Unique e-mail of user
        /// </summary>
        [Required]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        /// <summary>
        /// Unique skype login of user
        /// </summary>
        [Index(IsUnique = true)]
        public string SkypeLogin { get; set; }

        /// <summary>
        /// Signature of user
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// Image URL address (avatar of user)
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// Enumeration of roles, e.g. User, Manager, Support, Admin (see TestTask.Models.UserRolesEnum)
        /// </summary>
        [DefaultRole(UserRolesEnum.User)]
        public UserRolesEnum Role { get; set; }

        /// <summary>
        /// If this user is disabled or not
        /// </summary>
        public bool? IsDisabled { get; set; }
    }
}