﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vet.Data;
using Vet.Domain;

namespace Vet.Websde.Controllers
{
    public class HistorialPacientesController : Controller
    {
        private VetDbContext db = new VetDbContext();

        // GET: HistorialPacientes
        public ActionResult Index()
        {
            var historialPacientes = db.HistorialPacientes.Include(h => h.Paciente);
            return View(historialPacientes.ToList());
        }

        // GET: HistorialPacientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistorialPaciente historialPaciente = db.HistorialPacientes.Find(id);
            if (historialPaciente == null)
            {
                return HttpNotFound();
            }
            return View(historialPaciente);
        }

        // GET: HistorialPacientes/Create
        public ActionResult Create()
        {
            ViewBag.IdPaciente = new SelectList(db.Pacientes, "Id", "Nombre");
            return View();
        }

        // POST: HistorialPacientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdPaciente,Descripcion")] HistorialPaciente historialPaciente)
        {
            if (ModelState.IsValid)
            {
                db.HistorialPacientes.Add(historialPaciente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPaciente = new SelectList(db.Pacientes, "Id", "Nombre", historialPaciente.IdPaciente);
            return View(historialPaciente);
        }

        // GET: HistorialPacientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistorialPaciente historialPaciente = db.HistorialPacientes.Find(id);
            if (historialPaciente == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPaciente = new SelectList(db.Pacientes, "Id", "Nombre", historialPaciente.IdPaciente);
            return View(historialPaciente);
        }

        // POST: HistorialPacientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdPaciente,Descripcion")] HistorialPaciente historialPaciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historialPaciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPaciente = new SelectList(db.Pacientes, "Id", "Nombre", historialPaciente.IdPaciente);
            return View(historialPaciente);
        }

        // GET: HistorialPacientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistorialPaciente historialPaciente = db.HistorialPacientes.Find(id);
            if (historialPaciente == null)
            {
                return HttpNotFound();
            }
            return View(historialPaciente);
        }

        // POST: HistorialPacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HistorialPaciente historialPaciente = db.HistorialPacientes.Find(id);
            db.HistorialPacientes.Remove(historialPaciente);
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