using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KendoUI.Models.Default;
using KendoUI.Models.OData.Models;
using KendoUI.Views.App_LocalResources;

namespace KendoUI.Controllers
{
    public class ProductsController : Controller
    {
        private string serviceRoot = "http://localhost:9171/odata";
        private Container container;

        public ProductsController()
        {
            container = new Container(new Uri(serviceRoot));
        }

        //
        // GET: /Products/

        public ActionResult Index()
        {
            ViewBag.ServiceRoot = serviceRoot;

            var currencies = new[] { Currency.Cny, Currency.Usd, Currency.Hkd, Currency.Eur };
            ViewData["currenciesList"] = currencies;
            ViewData["currencies"] = new SelectList(currencies, "IsoNumericCode", "Iso3LetterCode");
            ViewData["categories"] = new SelectList(container.Categories, "ID", "Name");

            return View();
        }

        //
        // GET: /Products/Details/5

        public ActionResult Details(Guid id)
        {
            var product = container.Products.Where(p => p.ID == id).SingleOrDefault();
            return View(product);
        }

        //
        // GET: /Products/Create

        //public ActionResult Create()
        //{
        //    return View();
        //}

        //
        // POST: /Products/Create

        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //
        // GET: /Products/Edit/5

        //public ActionResult Edit(Guid id)
        //{
        //    return View();
        //}

        //
        // POST: /Products/Edit/5

        //[HttpPost]
        //public ActionResult Edit(Guid id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //
        // GET: /Products/Delete/5

        //public ActionResult Delete(Guid id)
        //{
        //    return View();
        //}

        //
        // POST: /Products/Delete/5

        //[HttpPost]
        //public ActionResult Delete(Guid id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
