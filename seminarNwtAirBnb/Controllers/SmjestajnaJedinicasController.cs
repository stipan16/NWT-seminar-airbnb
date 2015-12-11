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
    public class SmjestajnaJedinicasController : Controller
    {
        private ApartmaniContext db = new ApartmaniContext();

        // GET: SmjestajnaJedinicas
        public ActionResult Index()
        {
            return View(db.SmjestajneJedinice.ToList());
        }

        // GET: SmjestajnaJedinicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SmjestajnaJedinica smjestajnaJedinica = db.SmjestajneJedinice.Find(id);
            if (smjestajnaJedinica == null)
            {
                return HttpNotFound();
            }
            return View(smjestajnaJedinica);
        }

        // GET: SmjestajnaJedinicas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SmjestajnaJedinicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SmjestajnaJedinicaID,Naziv,Opis")] SmjestajnaJedinica smjestajnaJedinica)
        {
            if (ModelState.IsValid)
            {
                db.SmjestajneJedinice.Add(smjestajnaJedinica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(smjestajnaJedinica);
        }

        // GET: SmjestajnaJedinicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SmjestajnaJedinica smjestajnaJedinica = db.SmjestajneJedinice.Find(id);
            if (smjestajnaJedinica == null)
            {
                return HttpNotFound();
            }
            return View(smjestajnaJedinica);
        }

        // POST: SmjestajnaJedinicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SmjestajnaJedinicaID,Naziv,Opis")] SmjestajnaJedinica smjestajnaJedinica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(smjestajnaJedinica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(smjestajnaJedinica);
        }

        // GET: SmjestajnaJedinicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SmjestajnaJedinica smjestajnaJedinica = db.SmjestajneJedinice.Find(id);
            if (smjestajnaJedinica == null)
            {
                return HttpNotFound();
            }
            return View(smjestajnaJedinica);
        }

        // POST: SmjestajnaJedinicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SmjestajnaJedinica smjestajnaJedinica = db.SmjestajneJedinice.Find(id);
            db.SmjestajneJedinice.Remove(smjestajnaJedinica);
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
