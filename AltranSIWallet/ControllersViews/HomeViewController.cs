using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AltranSIWallet.Controllers;
using AltranSIWallet.Models;

namespace AltranSIWallet.ControllersViews
{
    public class HomeViewController : Controller
    {
        private ConsultantsController consultantController;

        public HomeViewController()
        {
            consultantController = new ConsultantsController();
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Consultant consultant = db.Profils.Find(id);
        //    if (consultant == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(consultant);
        //}

        // GET: Home/Create
        //public ActionResult Create()
        //{
        //    ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName");
        //    ViewBag.ManagerId = new SelectList(db.Profils, "Id", "Id");
        //    ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name");
        //    return View();
        //}

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,UserId,Level,SkillsFile,ProjectId,ManagerId")] Consultant consultant)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Profils.Add(consultant);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", consultant.UserId);
        //    ViewBag.ManagerId = new SelectList(db.Profils, "Id", "Id", consultant.ManagerId);
        //    ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", consultant.ProjectId);
        //    return View(consultant);
        //}

        // GET: Home/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Consultant consultant = db.Profils.Find(id);
        //    if (consultant == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", consultant.UserId);
        //    ViewBag.ManagerId = new SelectList(db.Profils, "Id", "Id", consultant.ManagerId);
        //    ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", consultant.ProjectId);
        //    return View(consultant);
        //}

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,UserId,Level,SkillsFile,ProjectId,ManagerId")] Consultant consultant)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(consultant).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", consultant.UserId);
        //    ViewBag.ManagerId = new SelectList(db.Profils, "Id", "Id", consultant.ManagerId);
        //    ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", consultant.ProjectId);
        //    return View(consultant);
        //}

        // GET: Home/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Consultant consultant = db.Profils.Find(id);
        //    if (consultant == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(consultant);
        //}

        // POST: Home/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Consultant consultant = db.Profils.Find(id);
        //    db.Profils.Remove(consultant);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
