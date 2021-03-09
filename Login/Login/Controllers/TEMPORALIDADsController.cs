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
    public class TEMPORALIDADsController : Controller
    {
        private graficoEntities db = new graficoEntities();

        // GET: TEMPORALIDADs
        public ActionResult Index()
        {
            return View(db.TEMPORALIDAD.ToList());
        }

        // GET: TEMPORALIDADs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEMPORALIDAD tEMPORALIDAD = db.TEMPORALIDAD.Find(id);
            if (tEMPORALIDAD == null)
            {
                return HttpNotFound();
            }
            return View(tEMPORALIDAD);
        }

        // GET: TEMPORALIDADs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TEMPORALIDADs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,descripcion,auxiliar,fecha_inicio,fecha_termino")] TEMPORALIDAD tEMPORALIDAD)
        {
            if (ModelState.IsValid)
            {
                tEMPORALIDAD.id = db.TEMPORALIDAD.Max(x => x.id) + 1;
                db.TEMPORALIDAD.Add(tEMPORALIDAD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tEMPORALIDAD);
        }

        // GET: TEMPORALIDADs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEMPORALIDAD tEMPORALIDAD = db.TEMPORALIDAD.Find(id);
            if (tEMPORALIDAD == null)
            {
                return HttpNotFound();
            }
            return View(tEMPORALIDAD);
        }

        // POST: TEMPORALIDADs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,descripcion,auxiliar,fecha_inicio,fecha_termino")] TEMPORALIDAD tEMPORALIDAD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tEMPORALIDAD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tEMPORALIDAD);
        }

        // GET: TEMPORALIDADs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEMPORALIDAD tEMPORALIDAD = db.TEMPORALIDAD.Find(id);
            if (tEMPORALIDAD == null)
            {
                return HttpNotFound();
            }
            return View(tEMPORALIDAD);
        }

        // POST: TEMPORALIDADs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TEMPORALIDAD tEMPORALIDAD = db.TEMPORALIDAD.Find(id);
            db.TEMPORALIDAD.Remove(tEMPORALIDAD);
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
