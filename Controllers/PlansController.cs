﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZOOLO.Models;

namespace ZOOLO.Controllers
{
    public class PlansController : Controller
    {
        private Model1 db = new Model1();

        // GET: Plans
        public ActionResult Index()
        {
            var plans = db.Plans.Include(p => p.Zoologico);
            return View(plans.ToList());
        }

        // GET: Plans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plans plans = db.Plans.Find(id);
            if (plans == null)
            {
                return HttpNotFound();
            }
            return View(plans);
        }

        // GET: Plans/Create
        public ActionResult Create()
        {
            ViewBag.IdZooPlans = new SelectList(db.Zoologico, "IdZoo", "NombreZoo");
            return View();
        }

        // POST: Plans/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPlans,IdZooPlans,ZonaPlans,ValorPlans,ZonaAdicPlans")] Plans plans)
        {
            if (ModelState.IsValid)
            {
                db.Plans.Add(plans);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdZooPlans = new SelectList(db.Zoologico, "IdZoo", "NombreZoo", plans.IdZooPlans);
            return View(plans);
        }

        // GET: Plans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plans plans = db.Plans.Find(id);
            if (plans == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdZooPlans = new SelectList(db.Zoologico, "IdZoo", "NombreZoo", plans.IdZooPlans);
            return View(plans);
        }

        // POST: Plans/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPlans,IdZooPlans,ZonaPlans,ValorPlans,ZonaAdicPlans")] Plans plans)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plans).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdZooPlans = new SelectList(db.Zoologico, "IdZoo", "NombreZoo", plans.IdZooPlans);
            return View(plans);
        }

        // GET: Plans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plans plans = db.Plans.Find(id);
            if (plans == null)
            {
                return HttpNotFound();
            }
            return View(plans);
        }

        // POST: Plans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plans plans = db.Plans.Find(id);
            db.Plans.Remove(plans);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
