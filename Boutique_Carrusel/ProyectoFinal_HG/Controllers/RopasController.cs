﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal_HG.Models;

namespace ProyectoFinal_HG.Controllers
{
    public class RopasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ropas
        [Authorize]
        public ActionResult Index()
        {
            var ropas = db.Ropas.Include(r => r.Modista);
            return View(ropas.ToList());
        }

        // GET: Ropas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ropa ropa = db.Ropas.Include(a => a.Modista.Categoria).
                Include(a => a.Modista).Where(a => a.Id == id)
                .FirstOrDefault();
            if (ropa == null)
            {
                return HttpNotFound();
            }
            return View(ropa);
        }
        [Authorize]
        // GET: Ropas/Create
        public ActionResult Create()
        {
            ViewBag.User = db.Modista.ToList();
            ViewBag.Categoria = db.Categorias.ToList();
            return View();
        }

        // POST: Ropas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(Ropa ropa, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string path = Server.MapPath("~/Upload/Ropa/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                if (file != null)
                {
                    
                    file.SaveAs(path + file.FileName);
                    ropa.Picture = file.FileName;
                }

                db.Ropas.Add(ropa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.User = db.Users.ToList();
            ViewBag.Categorias = db.Categorias.ToList();
            return View(ropa);
        }

        // GET: Ropas/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ropa ropa = db.Ropas.Find(id);
            if (ropa == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nombre", ropa.Modista);
            return View(ropa);
        }

        // POST: Ropas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,Precio,CategoriaId")] Ropa ropa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ropa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nombre", ropa.DisenadorId);
            return View(ropa);
        }

        // GET: Ropas/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ropa ropa = db.Ropas.Find(id);
            if (ropa == null)
            {
                return HttpNotFound();
            }
            return View(ropa);
        }

        // POST: Ropas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Ropa ropa = db.Ropas.Find(id);
            db.Ropas.Remove(ropa);
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
