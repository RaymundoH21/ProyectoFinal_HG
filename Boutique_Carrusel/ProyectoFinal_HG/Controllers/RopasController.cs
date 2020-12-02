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
    [Authorize]
    public class RopasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ropas
        public ActionResult Index()
        {
            var ropas = db.Ropas.Include(r => r.Categoria);
            return View(ropas.ToList());
        }

        // GET: Ropas/Details/5
        public ActionResult Details(int? id)
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

        // GET: Ropas/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nombre");
            return View();
        }

        // POST: Ropas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,Precio,CategoriaId")] Ropa ropa)
        {
            if (ModelState.IsValid)
            {
                db.Ropas.Add(ropa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nombre", ropa.CategoriaId);
            return View(ropa);
        }

        // GET: Ropas/Edit/5
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
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nombre", ropa.CategoriaId);
            return View(ropa);
        }

        // POST: Ropas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,Precio,CategoriaId")] Ropa ropa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ropa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nombre", ropa.CategoriaId);
            return View(ropa);
        }

        // GET: Ropas/Delete/5
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
