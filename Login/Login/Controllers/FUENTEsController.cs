using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Login.Models;

namespace Login.Controllers
{
    public class FUENTEsController : Controller
    {
        private graficoEntities db = new graficoEntities();

        // GET: FUENTEs
        public ActionResult Index()
        {
            return View(db.FUENTE.ToList());
        }

        // GET: FUENTEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FUENTE fUENTE = db.FUENTE.Find(id);
            if (fUENTE == null)
            {
                return HttpNotFound();
            }
            return View(fUENTE);
        }

        // GET: FUENTEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FUENTEs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,descripcion,auxiliar,url,fecha")] FUENTE fUENTE)
        {
            if (ModelState.IsValid)
            {
                fUENTE.id = db.FUENTE.Max(x => x.id) +1;
                db.FUENTE.Add(fUENTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fUENTE);
        }

        // GET: FUENTEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FUENTE fUENTE = db.FUENTE.Find(id);
            if (fUENTE == null)
            {
                return HttpNotFound();
            }
            return View(fUENTE);
        }

        // POST: FUENTEs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,descripcion,auxiliar,url,fecha")] FUENTE fUENTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fUENTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fUENTE);
        }

        // GET: FUENTEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FUENTE fUENTE = db.FUENTE.Find(id);
            if (fUENTE == null)
            {
                return HttpNotFound();
            }
            return View(fUENTE);
        }

        // POST: FUENTEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FUENTE fUENTE = db.FUENTE.Find(id);
            db.FUENTE.Remove(fUENTE);
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
