using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitirmeCalismasi.Controllers
{
    public class MedicineController : Controller
    {
        MedicineManager mm = new MedicineManager(new EfMedicineDal());
        // GET: Medicine
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult IlacKarsilastir(string ilac1, string ilac2)
        {
            int etkenMadde;
            TempData["Veri"] = "Bu bir TempDate'da taşınan veridir.";
               //TempData["myKey"] = "degerler";
            var Bulunanilac1 = mm.GetList().FirstOrDefault(x => x.MedicineName == ilac1);
            var Bulunanilac2 = mm.GetList().FirstOrDefault(x => x.MedicineName == ilac2);
            if (Bulunanilac1.MedicineName != null && Bulunanilac2.MedicineName !=null)
            {
                if (Bulunanilac1.ActiveIngredientID == Bulunanilac2.ActiveIngredientID)
                {
                    etkenMadde = 1;
                    ViewBag.deger1 = etkenMadde.ToString();
                    return View();
                }
                else
                {
                    etkenMadde = 2;
                    ViewBag.d = etkenMadde.ToString();
                    return View();
                }
                
            }
            else
            {
                etkenMadde = 3;
                ViewBag.d = etkenMadde.ToString();
                return View();
            }
            
        }

        //[HttpPost]
        //public ActionResult IlacKarsilastir(Medicine medicine)
        //{
            
           
        //}
    }
}