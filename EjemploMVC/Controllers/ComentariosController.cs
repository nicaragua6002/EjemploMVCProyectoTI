﻿using System;
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
    public class ComentariosController : Controller
    {
        private ProyectoTIModelContainer db = new ProyectoTIModelContainer();

        // GET: Comentarios
        public ActionResult Index()
        {
            var comentarios = db.Comentarios.Include(c => c.Tarea).Include(c => c.Usuario);
            return View(comentarios.ToList());
        }

        // GET: Comentarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentarios.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        // GET: Comentarios/Create
        public ActionResult Create()
        {
            ViewBag.TareaId = new SelectList(db.Tareas, "Id", "Nombre");
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "NombreUsuario");
            return View();
        }

        // POST: Comentarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Texto,Fecha,TareaId,UsuarioId")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                db.Comentarios.Add(comentario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TareaId = new SelectList(db.Tareas, "Id", "Nombre", comentario.TareaId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "NombreUsuario", comentario.UsuarioId);
            return View(comentario);
        }

        // GET: Comentarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentarios.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            ViewBag.TareaId = new SelectList(db.Tareas, "Id", "Nombre", comentario.TareaId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "NombreUsuario", comentario.UsuarioId);
            return View(comentario);
        }

        // POST: Comentarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Texto,Fecha,TareaId,UsuarioId")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comentario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TareaId = new SelectList(db.Tareas, "Id", "Nombre", comentario.TareaId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "NombreUsuario", comentario.UsuarioId);
            return View(comentario);
        }

        // GET: Comentarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentarios.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        // POST: Comentarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comentario comentario = db.Comentarios.Find(id);
            db.Comentarios.Remove(comentario);
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
