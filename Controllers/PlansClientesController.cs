using System;
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
    public class PlansClientesController : Controller
    {
        private Model1 db = new Model1();

        // GET: PlansClientes
        public ActionResult Index()
        {
            var plansCliente = db.PlansCliente.Include(p => p.Cliente).Include(p => p.Plans);
            return View(plansCliente.ToList());
        }

        // GET: PlansClientes/Details/5
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

        // GET: PlansClientes/Create
        public ActionResult Create()
        {
            ViewBag.IdClie = new SelectList(db.Cliente, "IdClie", "NombreClie");
            ViewBag.IdPlans = new SelectList(db.Plans, "IdPlans", "ZonaPlans");
            return View();
        }

        // POST: PlansClientes/Create
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

        // GET: PlansClientes/Edit/5
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

        // POST: PlansClientes/Edit/5
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

        // GET: PlansClientes/Delete/5
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

        // POST: PlansClientes/Delete/5
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
