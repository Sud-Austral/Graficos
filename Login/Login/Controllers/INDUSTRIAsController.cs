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
    public class INDUSTRIAsController : Controller
    {
        private graficosEntities db = new graficosEntities();

        // GET: INDUSTRIAs
        public ActionResult Index()
        {
            return View(db.INDUSTRIA.ToList());
        }

        // GET: INDUSTRIAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INDUSTRIA iNDUSTRIA = db.INDUSTRIA.Find(id);
            if (iNDUSTRIA == null)
            {
                return HttpNotFound();
            }
            return View(iNDUSTRIA);
        }

        // GET: INDUSTRIAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: INDUSTRIAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,descripcion,auxiliar")] INDUSTRIA iNDUSTRIA)
        {
            if (ModelState.IsValid)
            {
                iNDUSTRIA.id = db.INDUSTRIA.Max(x => x.id) + 1;
                //iNDUSTRIA.auxiliar = Util.NumeroATexto(iNDUSTRIA.id) + iNDUSTRIA.nombre;
                db.INDUSTRIA.Add(iNDUSTRIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(iNDUSTRIA);
        }

        // GET: INDUSTRIAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INDUSTRIA iNDUSTRIA = db.INDUSTRIA.Find(id);
            if (iNDUSTRIA == null)
            {
                return HttpNotFound();
            }
            return View(iNDUSTRIA);
        }

        // POST: INDUSTRIAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,descripcion,auxiliar")] INDUSTRIA iNDUSTRIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNDUSTRIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iNDUSTRIA);
        }

        // GET: INDUSTRIAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INDUSTRIA iNDUSTRIA = db.INDUSTRIA.Find(id);
            if (iNDUSTRIA == null)
            {
                return HttpNotFound();
            }
            return View(iNDUSTRIA);
        }

        // POST: INDUSTRIAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            INDUSTRIA iNDUSTRIA = db.INDUSTRIA.Find(id);
            db.INDUSTRIA.Remove(iNDUSTRIA);
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
