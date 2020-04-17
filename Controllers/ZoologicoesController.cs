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
    public class ZoologicoesController : Controller
    {
        private Model1 db = new Model1();

        // GET: Zoologicoes
        public ActionResult Index()
        {
            return View(db.Zoologico.ToList());
        }

        // GET: Zoologicoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zoologico zoologico = db.Zoologico.Find(id);
            if (zoologico == null)
            {
                return HttpNotFound();
            }
            return View(zoologico);
        }

        // GET: Zoologicoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zoologicoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdZoo,NombreZoo,DireccionZoo,TelefonoZoo,CorreoZoo")] Zoologico zoologico)
        {
            if (ModelState.IsValid)
            {
                db.Zoologico.Add(zoologico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zoologico);
        }

        // GET: Zoologicoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zoologico zoologico = db.Zoologico.Find(id);
            if (zoologico == null)
            {
                return HttpNotFound();
            }
            return View(zoologico);
        }

        // POST: Zoologicoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdZoo,NombreZoo,DireccionZoo,TelefonoZoo,CorreoZoo")] Zoologico zoologico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zoologico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zoologico);
        }

        // GET: Zoologicoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zoologico zoologico = db.Zoologico.Find(id);
            if (zoologico == null)
            {
                return HttpNotFound();
            }
            return View(zoologico);
        }

        // POST: Zoologicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zoologico zoologico = db.Zoologico.Find(id);
            db.Zoologico.Remove(zoologico);
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
