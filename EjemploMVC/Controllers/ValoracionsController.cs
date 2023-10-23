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
    public class ValoracionsController : Controller
    {
        private ProyectoTIModelContainer db = new ProyectoTIModelContainer();

        // GET: Valoracions
        public ActionResult Index()
        {
            var valoraciones = db.Valoraciones.Include(v => v.Tarea).Include(v => v.Usuario);
            return View(valoraciones.ToList());
        }

        // GET: Valoracions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valoracion valoracion = db.Valoraciones.Find(id);
            if (valoracion == null)
            {
                return HttpNotFound();
            }
            return View(valoracion);
        }

        // GET: Valoracions/Create
        public ActionResult Create()
        {
            ViewBag.TareaId = new SelectList(db.Tareas, "Id", "Nombre");
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "NombreUsuario");
            return View();
        }

        // POST: Valoracions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Puntuacion,TareaId,UsuarioId")] Valoracion valoracion)
        {
            if (ModelState.IsValid)
            {
                db.Valoraciones.Add(valoracion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TareaId = new SelectList(db.Tareas, "Id", "Nombre", valoracion.TareaId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "NombreUsuario", valoracion.UsuarioId);
            return View(valoracion);
        }

        // GET: Valoracions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valoracion valoracion = db.Valoraciones.Find(id);
            if (valoracion == null)
            {
                return HttpNotFound();
            }
            ViewBag.TareaId = new SelectList(db.Tareas, "Id", "Nombre", valoracion.TareaId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "NombreUsuario", valoracion.UsuarioId);
            return View(valoracion);
        }

        // POST: Valoracions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Puntuacion,TareaId,UsuarioId")] Valoracion valoracion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valoracion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TareaId = new SelectList(db.Tareas, "Id", "Nombre", valoracion.TareaId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "NombreUsuario", valoracion.UsuarioId);
            return View(valoracion);
        }

        // GET: Valoracions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valoracion valoracion = db.Valoraciones.Find(id);
            if (valoracion == null)
            {
                return HttpNotFound();
            }
            return View(valoracion);
        }

        // POST: Valoracions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Valoracion valoracion = db.Valoraciones.Find(id);
            db.Valoraciones.Remove(valoracion);
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
