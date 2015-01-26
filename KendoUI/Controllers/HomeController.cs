using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KendoUI.Models.Default;
using KendoUI.Models.OData.Models;

namespace KendoUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var serviceRoot = "http://localhost:9171/odata";
            var container = new Container(new Uri(serviceRoot));

            ViewBag.ServiceRoot = serviceRoot;
            var currencies = new[] { Currency.None, Currency.Cny, Currency.Usd, Currency.Hkd, Currency.Eur };
            ViewData["currencies"] = currencies;
            ViewData["categories"] = container.Categories;

            return View();
        }
    }
}
