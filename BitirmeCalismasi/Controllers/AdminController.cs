using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BitirmeCalismasi.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        UserLoginManager wm = new UserLoginManager(new EfUserDal());
        // GET: Admin
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context c = new Context();
            var adminuserinfo = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName &&
            x.AdminPassword==p.AdminPassword);
            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName, false);
                Session["AdminUserName"] = adminuserinfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(User user)
        {
            //Context c = new Context();
            //var userinfo = c.Users.FirstOrDefault(x => x.UserMail == user.UserMail &&
            //x.UserPassword == user.UserPassword);
            var userinfo = wm.GetUser(user.UserMail, user.UserPassword);
            if (userinfo != null)
            {
                FormsAuthentication.SetAuthCookie(userinfo.UserMail, false);
                Session["UserMail"] = userinfo.UserMail;
                return RedirectToAction("MyContent", "UserPanelContent");
            }
            else
            {
                return RedirectToAction("UserLogin");
            }
        }
            public ActionResult LogOut()
            {
                FormsAuthentication.SignOut();
                Session.Abandon();
                return RedirectToAction("Headings", "Default");
            }
        }
    }
