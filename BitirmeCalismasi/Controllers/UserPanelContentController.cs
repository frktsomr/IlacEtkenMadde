using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitirmeCalismasi.Controllers
{
    public class UserPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());

        Context c = new Context();
        public ActionResult MyContent(string p)
        {
            p = (string)Session["UserMail"];
            var useridinfo = c.Users.Where(x => x.UserMail == p).Select(y =>
                y.UserID).FirstOrDefault();

            var contentvalues = cm.GetListByUser(useridinfo);
            return View(contentvalues);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string mail = (string)Session["UserMail"];
            var useridinfo = c.Users.Where(x => x.UserMail == mail).Select(y =>
                y.UserID).FirstOrDefault();
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.UserID = useridinfo;
            content.ContentStatus = true;
            cm.ContentAddBL(content);
            return RedirectToAction("MyContent");
        }
    }
}