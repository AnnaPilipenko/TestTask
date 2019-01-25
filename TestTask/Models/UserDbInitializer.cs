using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    public class UserDbInitializer : DropCreateDatabaseAlways<UserContext>
    {
        protected override void Seed(UserContext db)
        {
            for (int i = 0; i < 10; i++)
            {
                var user = new User()
                {
                    Name = "Firstname Lastname",
                    Email = $"firstname.lastname{i + 1}@gmail.com",
                };

                db.Users.Add(user);
            }

            base.Seed(db);
        }
    }
}