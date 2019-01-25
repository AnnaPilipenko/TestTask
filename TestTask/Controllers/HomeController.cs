using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTask.Helpers;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserContext db = new UserContext();

        public ActionResult Index()
        {
            IEnumerable<User> users = this.db.Users;
            ViewBag.Users = users;
            return this.View();
        }
    }
}