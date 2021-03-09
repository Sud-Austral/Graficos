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
    public class TIPO_GRAFICOController : Controller
    {
        private graficoEntities db = new graficoEntities();

        // GET: TIPO_GRAFICO
        public ActionResult Index()
        {
            return View(db.TIPO_GRAFICO.ToList());
        }

        // GET: TIPO_GRAFICO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_GRAFICO tIPO_GRAFICO = db.TIPO_GRAFICO.Find(id);
            if (tIPO_GRAFICO == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_GRAFICO);
        }

        // GET: TIPO_GRAFICO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIPO_GRAFICO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,descripcion,auxiliar")] TIPO_GRAFICO tIPO_GRAFICO)
        {
            if (ModelState.IsValid)
            {
                tIPO_GRAFICO.id = db.TIPO_GRAFICO.Max(x => x.id) + 1;
                db.TIPO_GRAFICO.Add(tIPO_GRAFICO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIPO_GRAFICO);
        }

        // GET: TIPO_GRAFICO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_GRAFICO tIPO_GRAFICO = db.TIPO_GRAFICO.Find(id);
            if (tIPO_GRAFICO == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_GRAFICO);
        }

        // POST: TIPO_GRAFICO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,descripcion,auxiliar")] TIPO_GRAFICO tIPO_GRAFICO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPO_GRAFICO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIPO_GRAFICO);
        }

        // GET: TIPO_GRAFICO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_GRAFICO tIPO_GRAFICO = db.TIPO_GRAFICO.Find(id);
            if (tIPO_GRAFICO == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_GRAFICO);
        }

        // POST: TIPO_GRAFICO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIPO_GRAFICO tIPO_GRAFICO = db.TIPO_GRAFICO.Find(id);
            db.TIPO_GRAFICO.Remove(tIPO_GRAFICO);
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
