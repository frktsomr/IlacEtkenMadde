using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitirmeCalismasi.Controllers
{
    public class UserController : Controller
    {
        UserManager um = new UserManager(new EfUserDal());
        public ActionResult Index()
        {
            var UserValues = um.GetList();
            return View(UserValues);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(User user )
        {
            UserValidator uservalidator = new UserValidator();
            ValidationResult result = uservalidator.Validate(user);
            if(result.IsValid)
            {
                um.UserAdd(user);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}