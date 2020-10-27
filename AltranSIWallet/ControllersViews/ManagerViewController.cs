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

        // GET: ManagerView/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // GET: ManagerView/Create
        public ActionResult Create()
        {
            return View();
        }
    }
}
