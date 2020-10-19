using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AltranSIWallet.ControllersViews
{
    public class ManagerViewController : Controller
    {
        // GET: ManagerView
        public ActionResult Index()
        {
            return View();
        }

        // GET: ManagerView/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManagerView/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagerView/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ManagerView/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManagerView/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ManagerView/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManagerView/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
