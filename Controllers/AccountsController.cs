using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Test.Data;
using Test.Models;

namespace Test.Controllers
{
    public class AccountsController : Controller
    {
        BLL_User bll_user = new BLL_User(); 
        // GET: Accounts
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            EMPTYDBEntities context = new EMPTYDBEntities();

            var userData = context.Users.FirstOrDefault(x => x.email == model.Email.ToLower() && x.password == model.Password);
            
            if(userData != null)
            {
                Session["Name"] = userData.name;
                Session["Role"] = userData.role;
                FormsAuthentication.SetAuthCookie(userData.name, false);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(SignupViewModel model)
        {
            var result= bll_user.AddUser(model);
            if (result > 0)
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}