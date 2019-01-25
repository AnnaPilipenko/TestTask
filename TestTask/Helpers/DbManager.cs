using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TestTask.Models;

namespace TestTask.Helpers
{
    public static class DbManager
    {
        /// <summary>
        /// Default Max returned records in one query
        /// </summary>
        private static readonly int DefaultLimit = 1000;

        #region Users

        /// <summary>
        /// Search for user
        /// </summary>
        /// <param name="db">database context</param>
        /// <param name="id">id of user</param>
        /// <returns>task (result contains user or default(User))</returns>
        public static async Task<User> GetUser(this UserContext db, long id)
        {
            return await db.Users.FirstOrDefaultAsync(user => user.Id == id);
        }

        /// <summary>
        /// Search for user
        /// </summary>
        /// <param name="db">database context</param>
        /// <param name="emailOrSkypeLogin">user's e-mail or skype login, case insensitive</param>
        /// <returns>task (result contains user or default(User))</returns>
        public static async Task<User> GetUserAsync(this UserContext db, string emailOrSkypeLogin)
        {
             return await db.Users.FirstOrDefaultAsync(user => user.Email.Equals(emailOrSkypeLogin, StringComparison.InvariantCultureIgnoreCase) ||
                                               user.SkypeLogin.Equals(emailOrSkypeLogin, StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// Search for users
        /// </summary>
        /// <param name="db">database context</param>
        /// <param name="lastId">last id returned in the previous query, is used when we have limit and scrolling to get the next batch of data</param>
        /// <param name="searchString">user's name, email or skype login, search as substring of chars, case insensitive</param>
        /// <param name="roles">comma separated enumeration of user roles (empty means any), e.g.: User, Manager, Support, Admin</param>
        /// <param name="isDisabled">search disabled users or not (null means any)</param>
        /// <param name="limit">maximum returned amount of records in one query</param>
        /// <returns>task (result contains list of users)</returns>
        public static async Task<List<User>> SearchUsersAsync(this UserContext db, long? lastId, string searchString, string roles, bool? isDisabled, int? limit)
        {
            if (!limit.HasValue || limit.Value <= 0)
            {
                limit = DefaultLimit;
            }

            List<UserRolesEnum> rolesList = null;
            if (!string.IsNullOrEmpty(roles))
            {
                rolesList = new List<UserRolesEnum>();

                string[] rolesStrings = roles.Split(',');
                for (int i = 0; i < rolesStrings.Length; i++)
                {
                    rolesList.Add((UserRolesEnum)Enum.Parse(typeof(UserRolesEnum), rolesStrings[i]));
                }
            }

            var users = (from user in db.Users
                         where (lastId.HasValue ? user.Id > lastId : true) &&
                               (user.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) || 
                                user.Email.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                                user.SkypeLogin.Contains(searchString, StringComparison.OrdinalIgnoreCase)) &&
                               (rolesList != null && rolesList.Count > 0 ? rolesList.Contains(user.Role) : true) &&
                               (isDisabled.HasValue ? user.IsDisabled.Equals(isDisabled) : true)
                         select user).Take((int)limit);

            return await users.ToListAsync();
        }
        #endregion
    }
}