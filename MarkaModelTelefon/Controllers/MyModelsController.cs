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
    public class MyModelsController : Controller
    {
        private AppConnectionDbString db = new AppConnectionDbString();

        // GET: MyModels
        public ActionResult Index()
        {
            var myModel = db.MyModel.Include(m => m.MyMarka);
            return View(myModel.ToList());
        }

        // GET: MyModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyModel myModel = db.MyModel.Find(id);
            if (myModel == null)
            {
                return HttpNotFound();
            }
            return View(myModel);
        }

        // GET: MyModels/Create
        public ActionResult Create()
        {
            ViewBag.MarkaId = new SelectList(db.MyMarka, "MarkaId", "MarkaAd");
            return View();
        }

        // POST: MyModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModelId,ModelAd,MarkaId")] MyModel myModel)
        {
            if (ModelState.IsValid)
            {
                db.MyModel.Add(myModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MarkaId = new SelectList(db.MyMarka, "MarkaId", "MarkaAd", myModel.MarkaId);
            return View(myModel);
        }

        // GET: MyModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyModel myModel = db.MyModel.Find(id);
            if (myModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.MarkaId = new SelectList(db.MyMarka, "MarkaId", "MarkaAd", myModel.MarkaId);
            return View(myModel);
        }

        // POST: MyModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModelId,ModelAd,MarkaId")] MyModel myModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MarkaId = new SelectList(db.MyMarka, "MarkaId", "MarkaAd", myModel.MarkaId);
            return View(myModel);
        }

        // GET: MyModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyModel myModel = db.MyModel.Find(id);
            if (myModel == null)
            {
                return HttpNotFound();
            }
            return View(myModel);
        }

        // POST: MyModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyModel myModel = db.MyModel.Find(id);
            db.MyModel.Remove(myModel);
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
