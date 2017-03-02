using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP1.Controllers
{
    public class MathController : Controller
    {
        // GET: Math

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add(int? first, int? second)
        {
            ViewBag.First = first;
            ViewBag.Second = second;
            if (first == null || second == null)
            {
                ViewBag.Result = null;
            }
            else
                ViewBag.Result = first + second;
                
            return View();
        }

        public ActionResult Sub(int? first, int? second)
        {
            ViewBag.First = first;
            ViewBag.Second = second;
            if (first == null || second == null)
            {
                ViewBag.Result = null;
            }
            else
                ViewBag.Result = first - second;

            return View();
        }

        public ActionResult Mul(int? first, int? second)
        {
            ViewBag.First = first;
            ViewBag.Second = second;
            if (first == null || second == null)
            {
                ViewBag.Result = null;
            }
            else
                ViewBag.Result = first * second;

            return View();
        }

        public ActionResult Div(int? first, int? second)
        {
            ViewBag.First = first;
            ViewBag.Second = second;
            if (first == null || second == null || second == 0)
            {
                ViewBag.Result = null;
            }
            else
                ViewBag.Result = first / second;

            return View();
        }
    }
}