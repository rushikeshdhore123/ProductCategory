using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Master_With_CURD_Operations.Models;
using Master_With_CURD_Operations.DAL;

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
        public ActionResult Display()
        {
            DataTable dt = product.Display();
            ViewData["Data"] = dt;
            return View();
        }
    }
}