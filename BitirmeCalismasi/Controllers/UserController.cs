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
        UserValidator uservalidator = new UserValidator();
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

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            var uservalue = um.GetByID(id);
            return View(uservalue);
        }

        [HttpPost]
        public ActionResult EditUser(User user)
        {
            ValidationResult result = uservalidator.Validate(user);
            if (result.IsValid)
            {
                user.UserStatus = true;
                um.UserUptade(user);
                
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