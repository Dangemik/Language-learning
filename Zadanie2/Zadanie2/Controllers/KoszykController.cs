using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zadanie2.Base;
using Zadanie2.Models;
using Zadanie2.Models.Nhibernate;

namespace Zadanie2.Controllers
{
    public class KoszykController : Controller
    {
        BaseService baseService = new BaseService();
        // GET: Koszyk
        public ActionResult Index()
        {
            using (ISession session = NHibertnateSession.OpenSession())
            {
                var products = session.Query<Produkt>().ToList();
                return View(products);
            }
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Produkt produkt)
        {
            try
            {
                baseService.DodajDoKoszyka(produkt);
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            using (ISession session = NHibertnateSession.OpenSession())
            {
                var employee = session.Get<Produkt>(id);
                return View(employee);
            }
        }


        [HttpPost]
        public ActionResult Delete(int id, Produkt produkt)
        {
            try
            {
                baseService.UsunZKoszyka(id);
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                return View();
            }
        }

    }

}