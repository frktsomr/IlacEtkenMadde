using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace BitirmeCalismasi.Controllers
{
    public class UserPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        UserManager um = new UserManager(new EfUserDal());
        Context c = new Context();

        //int id;
        [HttpGet]
        public ActionResult UserProfile(int id=0)
        {
            string p = (string)Session["UserMail"];
             id = c.Users.Where(x => x.UserMail == p).Select(y => y.UserID).FirstOrDefault();
            var uservalue = um.GetByID(id);
            return View(uservalue);
        }

        [HttpPost]
        public ActionResult UserProfile(User user)
        {
            UserValidator uservalidator = new UserValidator();
            ValidationResult result = uservalidator.Validate(user);
            if (result.IsValid)
            {
                um.UserUptade(user);
                return RedirectToAction("UserProfile","UserPanel");
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
        public ActionResult MyHeading(string p)
        {
           
            p = (string)Session["UserMail"];
            var useridinfo = c.Users.Where(x => x.UserMail == p).Select(y => y.UserID).FirstOrDefault();
            //id = useridinfo;
            var values = hm.GetListByUser(useridinfo);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string usermailinfo = (string)Session["UserMail"];
            var useridinfo = c.Users.Where(x => x.UserMail == usermailinfo).Select(y => y.UserID).FirstOrDefault();
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.UserID = useridinfo;
            heading.HeadingStatus = true;
            hm.HeadingAddBL(heading);

            return RedirectToAction("MyHeading");
            
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();

            ViewBag.vlc = valuecategory;
            var Headingvalue = hm.GetByID(id);
            return View(Headingvalue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            heading.HeadingStatus = true;
            hm.HeadingUpdate(heading);
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeading(int id)
        {
            var HeadingValue = hm.GetByID(id);
            HeadingValue.HeadingStatus = false;
            hm.HeadingDelete(HeadingValue);
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeading(int p=1)
        {
            var headings = hm.GetList().ToPagedList(p, 8);
            return View(headings);
        }
    }
}