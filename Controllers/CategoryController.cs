using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Master_With_CURD_Operations.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Master_With_CURD_Operations.DAL;


namespace Master_With_CURD_Operations.Controllers
{
    public class CategoryController : Controller
    {
        DalCategory category = new DalCategory();

        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(Category c)
        {
            category.Insert(c);
            return RedirectToAction("Display");
        }
        
        public ActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Update(Category c)
        {
            category.Update(c);
            return RedirectToAction("Display");
        }

        [HttpGet]
        public ActionResult Delete(Category c)
        {
            category.Delete(c);
            return RedirectToAction("Display");

        }
        [HttpGet]
        public ActionResult Display()
        {
            DataTable dt = category.Display();
            ViewData["Data"] = dt;
            return View();
        }

    }
}