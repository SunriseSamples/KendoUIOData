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
            string serviceUri = "http://localhost:9171/odata";
            var container = new Container(new Uri(serviceUri));

            var currencies = new[] { Currency.Cny, Currency.Usd, Currency.Hkd, Currency.Eur, Currency.All };
            ViewData["currencies"] = currencies;
            ViewData["categories"] = container.Categories;
            return View();
        }
    }
}
