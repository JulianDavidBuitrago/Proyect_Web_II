﻿using System;
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
    public class ParqueadreoVehiculoeController : Controller
    {
        private ZoologicoEntities db = new ZoologicoEntities();

        // GET: ParqueadreoVehiculoe
        public ActionResult Index()
        {
            var parqueadreoVehiculo = db.ParqueadreoVehiculo.Include(p => p.Parqueadreo).Include(p => p.Vehiculo);
            return View(parqueadreoVehiculo.ToList());
        }

        // GET: ParqueadreoVehiculoe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParqueadreoVehiculo parqueadreoVehiculo = db.ParqueadreoVehiculo.Find(id);
            if (parqueadreoVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(parqueadreoVehiculo);
        }

        // GET: ParqueadreoVehiculoe/Create
        public ActionResult Create()
        {
            ViewBag.IdPar = new SelectList(db.Parqueadreo, "IdPar", "TelefonoPar");
            ViewBag.IdVehi = new SelectList(db.Vehiculo, "IdVehi", "MarcaVehi");
            return View();
        }

        // POST: ParqueadreoVehiculoe/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdParqueadreoVehiculo,IdPar,IdVehi,FechaEntradaParVehi,HoraEntradaParVehi,FechaSalidaParVehi,HoraSalidaParVehi,NumPersonasPlansClie,ValorPlansClie")] ParqueadreoVehiculo parqueadreoVehiculo)
        {
            if (ModelState.IsValid)
            {
                db.ParqueadreoVehiculo.Add(parqueadreoVehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPar = new SelectList(db.Parqueadreo, "IdPar", "TelefonoPar", parqueadreoVehiculo.IdPar);
            ViewBag.IdVehi = new SelectList(db.Vehiculo, "IdVehi", "MarcaVehi", parqueadreoVehiculo.IdVehi);
            return View(parqueadreoVehiculo);
        }

        // GET: ParqueadreoVehiculoe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParqueadreoVehiculo parqueadreoVehiculo = db.ParqueadreoVehiculo.Find(id);
            if (parqueadreoVehiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPar = new SelectList(db.Parqueadreo, "IdPar", "TelefonoPar", parqueadreoVehiculo.IdPar);
            ViewBag.IdVehi = new SelectList(db.Vehiculo, "IdVehi", "MarcaVehi", parqueadreoVehiculo.IdVehi);
            return View(parqueadreoVehiculo);
        }

        // POST: ParqueadreoVehiculoe/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdParqueadreoVehiculo,IdPar,IdVehi,FechaEntradaParVehi,HoraEntradaParVehi,FechaSalidaParVehi,HoraSalidaParVehi,NumPersonasPlansClie,ValorPlansClie")] ParqueadreoVehiculo parqueadreoVehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parqueadreoVehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPar = new SelectList(db.Parqueadreo, "IdPar", "TelefonoPar", parqueadreoVehiculo.IdPar);
            ViewBag.IdVehi = new SelectList(db.Vehiculo, "IdVehi", "MarcaVehi", parqueadreoVehiculo.IdVehi);
            return View(parqueadreoVehiculo);
        }

        // GET: ParqueadreoVehiculoe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParqueadreoVehiculo parqueadreoVehiculo = db.ParqueadreoVehiculo.Find(id);
            if (parqueadreoVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(parqueadreoVehiculo);
        }

        // POST: ParqueadreoVehiculoe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParqueadreoVehiculo parqueadreoVehiculo = db.ParqueadreoVehiculo.Find(id);
            db.ParqueadreoVehiculo.Remove(parqueadreoVehiculo);
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
