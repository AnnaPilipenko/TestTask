using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class HomeController : Controller
    {
        UserContext db = new UserContext();

        public ActionResult Index()
        {
            IEnumerable<User> users = db.Users;
            ViewBag.Users = users;
            return View();
        }
    }
}