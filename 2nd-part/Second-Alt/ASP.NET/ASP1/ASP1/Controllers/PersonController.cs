using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP1.Models;

namespace ASP1.Controllers
{
    public class ProductController : Controller
    {
        // GET: Person
        public ActionResult List()
        {
            var products = new Products();
            var models = products.GetProducts();
            return View(models);
        }

        public ActionResult View()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            Products products = new Products();
            products.Add(product);
            products.Serialize();
            return View();
        }

        
    }
}