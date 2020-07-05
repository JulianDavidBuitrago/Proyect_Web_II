using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZOO_PROYECT.Models;

namespace ZOO_PROYECT.Controllers
{
    public class PlansClienteController : Controller
    {
        private ZoologicoEntities db = new ZoologicoEntities();

        // GET: PlansCliente
        public ActionResult Index()
        {
            var plansCliente = db.PlansCliente.Include(p => p.Cliente).Include(p => p.Plans);
            return View(plansCliente.ToList());
        }

        // GET: PlansCliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlansCliente plansCliente = db.PlansCliente.Find(id);
            if (plansCliente == null)
            {
                return HttpNotFound();
            }
            return View(plansCliente);
        }

        // GET: PlansCliente/Create
        public ActionResult Create()
        {
            ViewBag.IdClie = new SelectList(db.Cliente, "IdClie", "NombreClie");
            ViewBag.IdPlans = new SelectList(db.Plans, "IdPlans", "ZonaPlans");
            return View();
        }

        // POST: PlansCliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPlansClie,IdClie,IdPlans,FechaPlansCliente,NumPersonasPlansClie,ValorPlansClie")] PlansCliente plansCliente)
        {
            if (ModelState.IsValid)
            {
                db.PlansCliente.Add(plansCliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdClie = new SelectList(db.Cliente, "IdClie", "NombreClie", plansCliente.IdClie);
            ViewBag.IdPlans = new SelectList(db.Plans, "IdPlans", "ZonaPlans", plansCliente.IdPlans);
            return View(plansCliente);
        }

        // GET: PlansCliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlansCliente plansCliente = db.PlansCliente.Find(id);
            if (plansCliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdClie = new SelectList(db.Cliente, "IdClie", "NombreClie", plansCliente.IdClie);
            ViewBag.IdPlans = new SelectList(db.Plans, "IdPlans", "ZonaPlans", plansCliente.IdPlans);
            return View(plansCliente);
        }

        // POST: PlansCliente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPlansClie,IdClie,IdPlans,FechaPlansCliente,NumPersonasPlansClie,ValorPlansClie")] PlansCliente plansCliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plansCliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdClie = new SelectList(db.Cliente, "IdClie", "NombreClie", plansCliente.IdClie);
            ViewBag.IdPlans = new SelectList(db.Plans, "IdPlans", "ZonaPlans", plansCliente.IdPlans);
            return View(plansCliente);
        }

        // GET: PlansCliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlansCliente plansCliente = db.PlansCliente.Find(id);
            if (plansCliente == null)
            {
                return HttpNotFound();
            }
            return View(plansCliente);
        }

        // POST: PlansCliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlansCliente plansCliente = db.PlansCliente.Find(id);
            db.PlansCliente.Remove(plansCliente);
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
