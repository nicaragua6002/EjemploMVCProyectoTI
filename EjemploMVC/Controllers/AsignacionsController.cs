using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EjemploMVC.Models;

namespace EjemploMVC.Controllers
{
    public class AsignacionsController : Controller
    {
        private ProyectoTIModelContainer db = new ProyectoTIModelContainer();

        // GET: Asignacions
        public ActionResult Index()
        {
            var asignaciones = db.Asignaciones.Include(a => a.Miembro).Include(a => a.Tarea);
            return View(asignaciones.ToList());
        }

        // GET: Asignacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignacion asignacion = db.Asignaciones.Find(id);
            if (asignacion == null)
            {
                return HttpNotFound();
            }
            return View(asignacion);
        }

        // GET: Asignacions/Create
        public ActionResult Create()
        {
            ViewBag.MiembroId = new SelectList(db.Miembros, "Id", "Nombre");
            ViewBag.TareaId = new SelectList(db.Tareas, "Id", "Nombre");
            return View();
        }

        // POST: Asignacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MiembroId,TareaId,Rol,Fecha")] Asignacion asignacion)
        {
            if (ModelState.IsValid)
            {
                db.Asignaciones.Add(asignacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MiembroId = new SelectList(db.Miembros, "Id", "Nombre", asignacion.MiembroId);
            ViewBag.TareaId = new SelectList(db.Tareas, "Id", "Nombre", asignacion.TareaId);
            return View(asignacion);
        }

        // GET: Asignacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignacion asignacion = db.Asignaciones.Find(id);
            if (asignacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.MiembroId = new SelectList(db.Miembros, "Id", "Nombre", asignacion.MiembroId);
            ViewBag.TareaId = new SelectList(db.Tareas, "Id", "Nombre", asignacion.TareaId);
            return View(asignacion);
        }

        // POST: Asignacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MiembroId,TareaId,Rol,Fecha")] Asignacion asignacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MiembroId = new SelectList(db.Miembros, "Id", "Nombre", asignacion.MiembroId);
            ViewBag.TareaId = new SelectList(db.Tareas, "Id", "Nombre", asignacion.TareaId);
            return View(asignacion);
        }

        // GET: Asignacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignacion asignacion = db.Asignaciones.Find(id);
            if (asignacion == null)
            {
                return HttpNotFound();
            }
            return View(asignacion);
        }

        // POST: Asignacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asignacion asignacion = db.Asignaciones.Find(id);
            db.Asignaciones.Remove(asignacion);
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
