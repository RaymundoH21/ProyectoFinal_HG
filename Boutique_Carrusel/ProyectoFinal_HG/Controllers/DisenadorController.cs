using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal_HG.Models;

namespace ProyectoFinal_HG.Controllers
{
    public class DisenadorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Disenador
        public ActionResult Index()
        {
            var modista = db.Modista.Include(d => d.Categoria);
            return View(modista.ToList());
        }

        // GET: Disenador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disenador disenador = db.Modista.Find(id);
            if (disenador == null)
            {
                return HttpNotFound();
            }
            return View(disenador);
        }

        // GET: Disenador/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nombre");
            return View();
        }

        // POST: Disenador/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CategoriaId,Phone,Email,Contact")] Disenador disenador)
        {
            if (ModelState.IsValid)
            {
                db.Modista.Add(disenador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nombre", disenador.CategoriaId);
            return View(disenador);
        }

        // GET: Disenador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disenador disenador = db.Modista.Find(id);
            if (disenador == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nombre", disenador.CategoriaId);
            return View(disenador);
        }

        // POST: Disenador/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CategoriaId,Phone,Email,Contact")] Disenador disenador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disenador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nombre", disenador.CategoriaId);
            return View(disenador);
        }

        // GET: Disenador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disenador disenador = db.Modista.Find(id);
            if (disenador == null)
            {
                return HttpNotFound();
            }
            return View(disenador);
        }

        // POST: Disenador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Disenador disenador = db.Modista.Find(id);
            db.Modista.Remove(disenador);
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
