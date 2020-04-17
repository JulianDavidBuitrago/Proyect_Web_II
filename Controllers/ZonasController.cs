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
    public class ZonasController : Controller
    {
        private Model1 db = new Model1();

        // GET: Zonas
        public ActionResult Index()
        {
            var zona = db.Zona.Include(z => z.Zoologico);
            return View(zona.ToList());
        }

        // GET: Zonas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zona zona = db.Zona.Find(id);
            if (zona == null)
            {
                return HttpNotFound();
            }
            return View(zona);
        }

        // GET: Zonas/Create
        public ActionResult Create()
        {
            ViewBag.IdZoo = new SelectList(db.Zoologico, "IdZoo", "NombreZoo");
            return View();
        }

        // POST: Zonas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdZona,IdZoo,NombreZona")] Zona zona)
        {
            if (ModelState.IsValid)
            {
                db.Zona.Add(zona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdZoo = new SelectList(db.Zoologico, "IdZoo", "NombreZoo", zona.IdZoo);
            return View(zona);
        }

        // GET: Zonas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zona zona = db.Zona.Find(id);
            if (zona == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdZoo = new SelectList(db.Zoologico, "IdZoo", "NombreZoo", zona.IdZoo);
            return View(zona);
        }

        // POST: Zonas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdZona,IdZoo,NombreZona")] Zona zona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdZoo = new SelectList(db.Zoologico, "IdZoo", "NombreZoo", zona.IdZoo);
            return View(zona);
        }

        // GET: Zonas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zona zona = db.Zona.Find(id);
            if (zona == null)
            {
                return HttpNotFound();
            }
            return View(zona);
        }

        // POST: Zonas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zona zona = db.Zona.Find(id);
            db.Zona.Remove(zona);
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
