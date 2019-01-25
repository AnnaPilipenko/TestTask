using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestTask.Models;

namespace TestTask.Helpers
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DefaultRole : Attribute
    {
        public DefaultRole(UserRolesEnum role)
        {
            this.Role = role;
        }

        public UserRolesEnum Role { get; set; }
    }
}