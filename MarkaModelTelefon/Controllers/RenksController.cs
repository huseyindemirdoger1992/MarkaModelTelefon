using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MarkaModelTelefon.Models;

namespace MarkaModelTelefon.Controllers
{
    public class RenksController : Controller
    {
        private AppConnectionDbString db = new AppConnectionDbString();

        // GET: Renks
        public ActionResult Index()
        {
            return View(db.Renk.ToList());
        }

        // GET: Renks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Renk renk = db.Renk.Find(id);
            if (renk == null)
            {
                return HttpNotFound();
            }
            return View(renk);
        }

        // GET: Renks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Renks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RenkId,RenkAd")] Renk renk)
        {
            if (ModelState.IsValid)
            {
                db.Renk.Add(renk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(renk);
        }

        // GET: Renks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Renk renk = db.Renk.Find(id);
            if (renk == null)
            {
                return HttpNotFound();
            }
            return View(renk);
        }

        // POST: Renks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RenkId,RenkAd")] Renk renk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(renk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(renk);
        }

        // GET: Renks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Renk renk = db.Renk.Find(id);
            if (renk == null)
            {
                return HttpNotFound();
            }
            return View(renk);
        }

        // POST: Renks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Renk renk = db.Renk.Find(id);
            db.Renk.Remove(renk);
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
