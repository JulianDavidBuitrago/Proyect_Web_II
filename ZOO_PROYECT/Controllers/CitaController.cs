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
    public class CitaController : Controller
    {
        private ZoologicoEntities db = new ZoologicoEntities();

        // GET: Cita
        public ActionResult Index()
        {
            var cita = db.Cita.Include(c => c.Animal).Include(c => c.Veterinario);
            return View(cita.ToList());
        }

        // GET: Cita/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // GET: Cita/Create
        public ActionResult Create()
        {
            ViewBag.IdAnimCita = new SelectList(db.Animal, "IdAnim", "CategoriaAnim");
            ViewBag.IdVeteCita = new SelectList(db.Veterinario, "IdVete", "NombreVete");
            return View();
        }

        // POST: Cita/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCita,IdAnimCita,IdVeteCita,FechaCita,HoraCita")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Cita.Add(cita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAnimCita = new SelectList(db.Animal, "IdAnim", "CategoriaAnim", cita.IdAnimCita);
            ViewBag.IdVeteCita = new SelectList(db.Veterinario, "IdVete", "NombreVete", cita.IdVeteCita);
            return View(cita);
        }

        // GET: Cita/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAnimCita = new SelectList(db.Animal, "IdAnim", "CategoriaAnim", cita.IdAnimCita);
            ViewBag.IdVeteCita = new SelectList(db.Veterinario, "IdVete", "NombreVete", cita.IdVeteCita);
            return View(cita);
        }

        // POST: Cita/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCita,IdAnimCita,IdVeteCita,FechaCita,HoraCita")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAnimCita = new SelectList(db.Animal, "IdAnim", "CategoriaAnim", cita.IdAnimCita);
            ViewBag.IdVeteCita = new SelectList(db.Veterinario, "IdVete", "NombreVete", cita.IdVeteCita);
            return View(cita);
        }

        // GET: Cita/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // POST: Cita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cita cita = db.Cita.Find(id);
            db.Cita.Remove(cita);
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
