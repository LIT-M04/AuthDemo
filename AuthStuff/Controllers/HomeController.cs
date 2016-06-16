using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AuthStuff.Models;
using UserAuth.Data;

namespace AuthStuff.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(string username, string password)
        {
            var manager = new UserManager(Properties.Settings.Default.ConStr);
            manager.AddUser(username, password);
            return Redirect("/home/signin");
        }

        public ActionResult Signin()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/home/secret");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Signin(string username, string password)
        {
            var manager = new UserManager(Properties.Settings.Default.ConStr);
            User user = manager.Login(username, password);
            if (user == null)
            {
                return Redirect("/home/signin");
            }

            FormsAuthentication.SetAuthCookie(username, true);
            return Redirect("/home/secret");
        }

        [Authorize]
        public ActionResult Secret()
        {
            var viewModel = new SecretViewModel { Username = User.Identity.Name };
            return View(viewModel);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

    }
}
