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
    public class CategoryController : Controller
    {
        CategoryManager _CategoryManager = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var _categoryvalues = _CategoryManager.GetList();
            return View(_categoryvalues);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
               
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            //_CategoryManager.CategoryAddBL(category);
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult validationResult = categoryValidator.Validate(category);

            if(validationResult.IsValid)
            {
                _CategoryManager.CategoryAddBL(category);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
            
        }
    }
}