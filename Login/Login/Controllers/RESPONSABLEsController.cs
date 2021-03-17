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
    public class RESPONSABLEsController : Controller
    {
        private graficosEntities db = new graficosEntities();

        // GET: RESPONSABLEs
        public ActionResult Index()
        {
            return View(db.RESPONSABLE.ToList());
        }

        // GET: RESPONSABLEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESPONSABLE rESPONSABLE = db.RESPONSABLE.Find(id);
            if (rESPONSABLE == null)
            {
                return HttpNotFound();
            }
            return View(rESPONSABLE);
        }

        // GET: RESPONSABLEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RESPONSABLEs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,descripcion,auxiliar")] RESPONSABLE rESPONSABLE)
        {
            if (ModelState.IsValid)
            {
                rESPONSABLE.id = db.RESPONSABLE.Max(x => x.id) + 1;
                db.RESPONSABLE.Add(rESPONSABLE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rESPONSABLE);
        }

        // GET: RESPONSABLEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESPONSABLE rESPONSABLE = db.RESPONSABLE.Find(id);
            if (rESPONSABLE == null)
            {
                return HttpNotFound();
            }
            return View(rESPONSABLE);
        }

        // POST: RESPONSABLEs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,descripcion,auxiliar")] RESPONSABLE rESPONSABLE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rESPONSABLE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rESPONSABLE);
        }

        // GET: RESPONSABLEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESPONSABLE rESPONSABLE = db.RESPONSABLE.Find(id);
            if (rESPONSABLE == null)
            {
                return HttpNotFound();
            }
            return View(rESPONSABLE);
        }

        // POST: RESPONSABLEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RESPONSABLE rESPONSABLE = db.RESPONSABLE.Find(id);
            db.RESPONSABLE.Remove(rESPONSABLE);
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
