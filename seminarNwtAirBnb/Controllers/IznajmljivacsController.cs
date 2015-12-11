using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using seminarNwtAirBnb.DAL;
using seminarNwtAirBnb.Models;

namespace seminarNwtAirBnb.Controllers
{
    public class IznajmljivacsController : Controller
    {
        private ApartmaniContext db = new ApartmaniContext();

        // GET: Iznajmljivacs
        public ActionResult Index()
        {
            return View(db.Iznajmljivaci.ToList());
        }

        // GET: Iznajmljivacs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Iznajmljivac iznajmljivac = db.Iznajmljivaci.Find(id);
            if (iznajmljivac == null)
            {
                return HttpNotFound();
            }
            return View(iznajmljivac);
        }

        // GET: Iznajmljivacs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Iznajmljivacs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IznajmljivacID,Ime,Prezime")] Iznajmljivac iznajmljivac)
        {
            if (ModelState.IsValid)
            {
                db.Iznajmljivaci.Add(iznajmljivac);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(iznajmljivac);
        }

        // GET: Iznajmljivacs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Iznajmljivac iznajmljivac = db.Iznajmljivaci.Find(id);
            if (iznajmljivac == null)
            {
                return HttpNotFound();
            }
            return View(iznajmljivac);
        }

        // POST: Iznajmljivacs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IznajmljivacID,Ime,Prezime")] Iznajmljivac iznajmljivac)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iznajmljivac).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iznajmljivac);
        }

        // GET: Iznajmljivacs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Iznajmljivac iznajmljivac = db.Iznajmljivaci.Find(id);
            if (iznajmljivac == null)
            {
                return HttpNotFound();
            }
            return View(iznajmljivac);
        }

        // POST: Iznajmljivacs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Iznajmljivac iznajmljivac = db.Iznajmljivaci.Find(id);
            db.Iznajmljivaci.Remove(iznajmljivac);
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
