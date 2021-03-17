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
    public class PARAMETROesController : Controller
    {
        private graficosEntities db = new graficosEntities();

        // GET: PARAMETROes
        public ActionResult Index()
        {
            return View(db.PARAMETRO.ToList());
        }

        // GET: PARAMETROes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARAMETRO pARAMETRO = db.PARAMETRO.Find(id);
            if (pARAMETRO == null)
            {
                return HttpNotFound();
            }
            return View(pARAMETRO);
        }

        // GET: PARAMETROes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PARAMETROes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,descripcion,auxiliar")] PARAMETRO pARAMETRO)
        {
            if (ModelState.IsValid)
            {
                pARAMETRO.id = db.PARAMETRO.Max(x => x.id) + 1;
                db.PARAMETRO.Add(pARAMETRO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pARAMETRO);
        }

        // GET: PARAMETROes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARAMETRO pARAMETRO = db.PARAMETRO.Find(id);
            if (pARAMETRO == null)
            {
                return HttpNotFound();
            }
            return View(pARAMETRO);
        }

        // POST: PARAMETROes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,descripcion,auxiliar")] PARAMETRO pARAMETRO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pARAMETRO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pARAMETRO);
        }

        // GET: PARAMETROes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARAMETRO pARAMETRO = db.PARAMETRO.Find(id);
            if (pARAMETRO == null)
            {
                return HttpNotFound();
            }
            return View(pARAMETRO);
        }

        // POST: PARAMETROes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PARAMETRO pARAMETRO = db.PARAMETRO.Find(id);
            db.PARAMETRO.Remove(pARAMETRO);
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
