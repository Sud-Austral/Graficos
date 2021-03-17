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
    public class SECTORsController : Controller
    {
        private graficosEntities db = new graficosEntities();

        // GET: SECTORs
        public ActionResult Index()
        {
            var sECTOR = db.SECTOR.Include(s => s.INDUSTRIA);
            return View(sECTOR.ToList());
        }

        // GET: SECTORs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SECTOR sECTOR = db.SECTOR.Find(id);
            if (sECTOR == null)
            {
                return HttpNotFound();
            }
            return View(sECTOR);
        }

        // GET: SECTORs/Create
        public ActionResult Create()
        {
            ViewBag.INDUSTRIA_id = new SelectList(db.INDUSTRIA, "id", "nombre");
            return View();
        }

        // POST: SECTORs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,descripcion,auxiliar,INDUSTRIA_id")] SECTOR sECTOR)
        {
            if (ModelState.IsValid)
            {
                sECTOR.id = db.SECTOR.Max(x => x.id) + 1;
                db.SECTOR.Add(sECTOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.INDUSTRIA_id = new SelectList(db.INDUSTRIA, "id", "nombre", sECTOR.INDUSTRIA_id);
            return View(sECTOR);
        }

        // GET: SECTORs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SECTOR sECTOR = db.SECTOR.Find(id);
            if (sECTOR == null)
            {
                return HttpNotFound();
            }
            ViewBag.INDUSTRIA_id = new SelectList(db.INDUSTRIA, "id", "nombre", sECTOR.INDUSTRIA_id);
            return View(sECTOR);
        }

        // POST: SECTORs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,descripcion,auxiliar,INDUSTRIA_id")] SECTOR sECTOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sECTOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.INDUSTRIA_id = new SelectList(db.INDUSTRIA, "id", "nombre", sECTOR.INDUSTRIA_id);
            return View(sECTOR);
        }

        // GET: SECTORs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SECTOR sECTOR = db.SECTOR.Find(id);
            if (sECTOR == null)
            {
                return HttpNotFound();
            }
            return View(sECTOR);
        }

        // POST: SECTORs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SECTOR sECTOR = db.SECTOR.Find(id);
            db.SECTOR.Remove(sECTOR);
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
