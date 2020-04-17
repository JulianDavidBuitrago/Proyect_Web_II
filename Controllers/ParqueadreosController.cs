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
    public class ParqueadreosController : Controller
    {
        private Model1 db = new Model1();

        // GET: Parqueadreos
        public ActionResult Index()
        {
            var parqueadreo = db.Parqueadreo.Include(p => p.Zoologico);
            return View(parqueadreo.ToList());
        }

        // GET: Parqueadreos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parqueadreo parqueadreo = db.Parqueadreo.Find(id);
            if (parqueadreo == null)
            {
                return HttpNotFound();
            }
            return View(parqueadreo);
        }

        // GET: Parqueadreos/Create
        public ActionResult Create()
        {
            ViewBag.IdZooPar = new SelectList(db.Zoologico, "IdZoo", "NombreZoo");
            return View();
        }

        // POST: Parqueadreos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPar,IdZooPar,TelefonoPar,ValorHora")] Parqueadreo parqueadreo)
        {
            if (ModelState.IsValid)
            {
                db.Parqueadreo.Add(parqueadreo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdZooPar = new SelectList(db.Zoologico, "IdZoo", "NombreZoo", parqueadreo.IdZooPar);
            return View(parqueadreo);
        }

        // GET: Parqueadreos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parqueadreo parqueadreo = db.Parqueadreo.Find(id);
            if (parqueadreo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdZooPar = new SelectList(db.Zoologico, "IdZoo", "NombreZoo", parqueadreo.IdZooPar);
            return View(parqueadreo);
        }

        // POST: Parqueadreos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPar,IdZooPar,TelefonoPar,ValorHora")] Parqueadreo parqueadreo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parqueadreo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdZooPar = new SelectList(db.Zoologico, "IdZoo", "NombreZoo", parqueadreo.IdZooPar);
            return View(parqueadreo);
        }

        // GET: Parqueadreos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parqueadreo parqueadreo = db.Parqueadreo.Find(id);
            if (parqueadreo == null)
            {
                return HttpNotFound();
            }
            return View(parqueadreo);
        }

        // POST: Parqueadreos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Parqueadreo parqueadreo = db.Parqueadreo.Find(id);
            db.Parqueadreo.Remove(parqueadreo);
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
