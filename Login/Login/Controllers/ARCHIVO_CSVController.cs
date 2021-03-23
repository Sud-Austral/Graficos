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
    public class ARCHIVO_CSVController : Controller
    {
        private graficosEntities db = new graficosEntities();

        // GET: ARCHIVO_CSV
        public ActionResult Index()
        {
            var aRCHIVO_CSV = db.ARCHIVO_CSV.Include(a => a.GRAFICO);
            return View(aRCHIVO_CSV.ToList());
        }

        // GET: ARCHIVO_CSV/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARCHIVO_CSV aRCHIVO_CSV = db.ARCHIVO_CSV.Find(id);
            if (aRCHIVO_CSV == null)
            {
                return HttpNotFound();
            }
            return View(aRCHIVO_CSV);
        }

        // GET: ARCHIVO_CSV/Create
        public ActionResult Create()
        {
            ViewBag.GRAFICO_id = new SelectList(db.GRAFICO, "id", "nombre");
            return View();
        }

        // POST: ARCHIVO_CSV/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "id,nombre,data,auxiliar,GRAFICO_id")] ARCHIVO_CSV aRCHIVO_CSV, HttpPostedFileBase fileBase)
        public ActionResult Create(ARCHIVO_CSV aRCHIVO_CSV, HttpPostedFileBase data)
        {
            if (ModelState.IsValid)
            {
                db.ARCHIVO_CSV.Add(aRCHIVO_CSV);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GRAFICO_id = new SelectList(db.GRAFICO, "id", "nombre", aRCHIVO_CSV.GRAFICO_id);
            return View(aRCHIVO_CSV);
        }

        // GET: ARCHIVO_CSV/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARCHIVO_CSV aRCHIVO_CSV = db.ARCHIVO_CSV.Find(id);
            if (aRCHIVO_CSV == null)
            {
                return HttpNotFound();
            }
            ViewBag.GRAFICO_id = new SelectList(db.GRAFICO, "id", "nombre", aRCHIVO_CSV.GRAFICO_id);
            return View(aRCHIVO_CSV);
        }

        // POST: ARCHIVO_CSV/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,data,auxiliar,GRAFICO_id")] ARCHIVO_CSV aRCHIVO_CSV)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aRCHIVO_CSV).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GRAFICO_id = new SelectList(db.GRAFICO, "id", "nombre", aRCHIVO_CSV.GRAFICO_id);
            return View(aRCHIVO_CSV);
        }

        // GET: ARCHIVO_CSV/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARCHIVO_CSV aRCHIVO_CSV = db.ARCHIVO_CSV.Find(id);
            if (aRCHIVO_CSV == null)
            {
                return HttpNotFound();
            }
            return View(aRCHIVO_CSV);
        }

        // POST: ARCHIVO_CSV/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ARCHIVO_CSV aRCHIVO_CSV = db.ARCHIVO_CSV.Find(id);
            db.ARCHIVO_CSV.Remove(aRCHIVO_CSV);
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
