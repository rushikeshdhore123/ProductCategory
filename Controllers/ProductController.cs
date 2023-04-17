using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Master_With_CURD_Operations.Models;

namespace Master_With_CURD_Operations.Controllers
{
    public class ProductController : Controller
    {
        DalProduct product = new DalProduct();
        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(Product p)
        {
            product.Insert(p);
            return RedirectToAction("Display");
        }

        public ActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Update(Product p)
        {
            product.Update(p);
            return RedirectToAction("Display");
        }

        [HttpGet]
        public ActionResult Delete(Product p)
        {
            product.Delete(p);
            return RedirectToAction("Display");

        }
        [HttpGet]
        public ActionResult Display(int? currentPage)
        {

            int page = 1;
            int pageSize = 5;

            if (currentPage > 1)
                page = (int)currentPage;

            int totalRecords = product.CountTotalRecords();
            int totalPages = totalRecords / pageSize;

            ViewBag.page = page;
            ViewBag.totalPages = totalPages + 1;

            DataTable dt = product.Display(page);
            ViewData["Data"] = dt;
            return View();
        }
        public ActionResult DisplayProductList(int? currentPage)
        {
            int page = 1;
            int pageSize = 5;

            if (currentPage > 1)
                page = (int)currentPage;

            //total records in product tables
            int totalRecords = product.CountTotalRecords();
            ViewBag.page = page;
            //to find total pages we require total records
            ViewBag.totalPages = (totalRecords/pageSize)+1;
           
            DataTable dt = product.DisplayProductList(page);
            ViewData["Data"] = dt;
            
            return View();
        }
    }
}