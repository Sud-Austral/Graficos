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
    public class UNIDAD_MEDIDAController : Controller
    {
        private graficosEntities db = new graficosEntities();

        // GET: UNIDAD_MEDIDA
        public ActionResult Index()
        {
            return View(db.UNIDAD_MEDIDA.ToList());
        }

        // GET: UNIDAD_MEDIDA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UNIDAD_MEDIDA uNIDAD_MEDIDA = db.UNIDAD_MEDIDA.Find(id);
            if (uNIDAD_MEDIDA == null)
            {
                return HttpNotFound();
            }
            return View(uNIDAD_MEDIDA);
        }

        // GET: UNIDAD_MEDIDA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UNIDAD_MEDIDA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,descripcion,auxiliar")] UNIDAD_MEDIDA uNIDAD_MEDIDA)
        {
            if (ModelState.IsValid)
            {
                uNIDAD_MEDIDA.id = db.UNIDAD_MEDIDA.Max(x => x.id) + 1;
                db.UNIDAD_MEDIDA.Add(uNIDAD_MEDIDA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uNIDAD_MEDIDA);
        }

        // GET: UNIDAD_MEDIDA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UNIDAD_MEDIDA uNIDAD_MEDIDA = db.UNIDAD_MEDIDA.Find(id);
            if (uNIDAD_MEDIDA == null)
            {
                return HttpNotFound();
            }
            return View(uNIDAD_MEDIDA);
        }

        // POST: UNIDAD_MEDIDA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,descripcion,auxiliar")] UNIDAD_MEDIDA uNIDAD_MEDIDA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uNIDAD_MEDIDA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uNIDAD_MEDIDA);
        }

        // GET: UNIDAD_MEDIDA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UNIDAD_MEDIDA uNIDAD_MEDIDA = db.UNIDAD_MEDIDA.Find(id);
            if (uNIDAD_MEDIDA == null)
            {
                return HttpNotFound();
            }
            return View(uNIDAD_MEDIDA);
        }

        // POST: UNIDAD_MEDIDA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UNIDAD_MEDIDA uNIDAD_MEDIDA = db.UNIDAD_MEDIDA.Find(id);
            db.UNIDAD_MEDIDA.Remove(uNIDAD_MEDIDA);
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
