﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AltranSIWallet.ControllersViews
{
    public class ConsultantViewController : Controller
    {
        // GET: ConsultantView
        public ActionResult Index()
        {
            return View();
        }

        // GET: ConsultantView/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ConsultantView/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: ConsultantView/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ConsultantView/Edit/5
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

        // GET: ConsultantView/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ConsultantView/Delete/5
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
