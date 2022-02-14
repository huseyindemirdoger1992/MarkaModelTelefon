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
    public class MyTelefonsController : Controller
    {
        private AppConnectionDbString db = new AppConnectionDbString();

        // GET: MyTelefons
        public ActionResult Index()
        {
            var myTelefon = db.MyTelefon.Include(m => m.MyModel).Include(m => m.Renk);
            return View(myTelefon.ToList());
        }

        // GET: MyTelefons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyTelefon myTelefon = db.MyTelefon.Find(id);
            if (myTelefon == null)
            {
                return HttpNotFound();
            }
            return View(myTelefon);
        }

        // GET: MyTelefons/Create
        public ActionResult Create()
        {
            ViewBag.ModelId = new SelectList(db.MyModel, "ModelId", "ModelAd");
            ViewBag.RenkId = new SelectList(db.Renk, "RenkId", "RenkAd");
            return View();
        }

        // POST: MyTelefons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TelefonId,RenkId,TelefonGRM,TelefonMA,TelefonOnKameraPX,TelefonOnArkaKameraPX,GarantiDurumu,Adet,ModelId")] MyTelefon myTelefon)
        {
            if (ModelState.IsValid)
            {
                db.MyTelefon.Add(myTelefon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ModelId = new SelectList(db.MyModel, "ModelId", "ModelAd", myTelefon.ModelId);
            ViewBag.RenkId = new SelectList(db.Renk, "RenkId", "RenkAd", myTelefon.RenkId);
            return View(myTelefon);
        }

        // GET: MyTelefons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyTelefon myTelefon = db.MyTelefon.Find(id);
            if (myTelefon == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModelId = new SelectList(db.MyModel, "ModelId", "ModelAd", myTelefon.ModelId);
            ViewBag.RenkId = new SelectList(db.Renk, "RenkId", "RenkAd", myTelefon.RenkId);
            return View(myTelefon);
        }

        // POST: MyTelefons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TelefonId,RenkId,TelefonGRM,TelefonMA,TelefonOnKameraPX,TelefonOnArkaKameraPX,GarantiDurumu,Adet,ModelId")] MyTelefon myTelefon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myTelefon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ModelId = new SelectList(db.MyModel, "ModelId", "ModelAd", myTelefon.ModelId);
            ViewBag.RenkId = new SelectList(db.Renk, "RenkId", "RenkAd", myTelefon.RenkId);
            return View(myTelefon);
        }

        // GET: MyTelefons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyTelefon myTelefon = db.MyTelefon.Find(id);
            if (myTelefon == null)
            {
                return HttpNotFound();
            }
            return View(myTelefon);
        }

        // POST: MyTelefons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyTelefon myTelefon = db.MyTelefon.Find(id);
            db.MyTelefon.Remove(myTelefon);
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
