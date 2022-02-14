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
    public class MyMarkasController : Controller
    {
        private AppConnectionDbString db = new AppConnectionDbString();

        // GET: MyMarkas
        public ActionResult Index()
        {
            return View(db.MyMarka.ToList());
        }

        // GET: MyMarkas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyMarka myMarka = db.MyMarka.Find(id);
            if (myMarka == null)
            {
                return HttpNotFound();
            }
            return View(myMarka);
        }

        // GET: MyMarkas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyMarkas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MarkaId,MarkaAd")] MyMarka myMarka)
        {
            if (ModelState.IsValid)
            {
                db.MyMarka.Add(myMarka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(myMarka);
        }

        // GET: MyMarkas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyMarka myMarka = db.MyMarka.Find(id);
            if (myMarka == null)
            {
                return HttpNotFound();
            }
            return View(myMarka);
        }

        // POST: MyMarkas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MarkaId,MarkaAd")] MyMarka myMarka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myMarka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(myMarka);
        }

        // GET: MyMarkas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyMarka myMarka = db.MyMarka.Find(id);
            if (myMarka == null)
            {
                return HttpNotFound();
            }
            return View(myMarka);
        }

        // POST: MyMarkas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyMarka myMarka = db.MyMarka.Find(id);
            db.MyMarka.Remove(myMarka);
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
