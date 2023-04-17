using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Master_With_CURD_Operations.Models;
using System.Data;

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
        public ActionResult Display(int? currentPage)
        { 
            int page = 1;
            int pageSize = 5;
            
            if (currentPage>1)
                page = (int)currentPage;

            int totalRecords = category.CountTotalRecords();
            int totalPages = totalRecords / pageSize;
    
            ViewBag.page = page;
            ViewBag.totalPages = totalPages+1;

            DataTable dt = category.Display(page);
            ViewData["Data"] = dt;

            return View();
        }

    }
}
            

        


