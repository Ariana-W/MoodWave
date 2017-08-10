using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Moodwave5.Models;

namespace Moodwave5.Controllers
{
    public class WavesController : Controller
    {
        private Moodwave1Entities db = new Moodwave1Entities();

        // GET: Waves
        public ActionResult Index()
        {
            return View(db.Waves.ToList());
        }

        // GET: Waves/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wave wave = db.Waves.Find(id);
            if (wave == null)
            {
                return HttpNotFound();
            }
            return View(wave);
        }

        // GET: Waves/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Waves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mood,waveID")] Wave wave)
        {
            if (ModelState.IsValid)
            {
                db.Waves.Add(wave);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wave);
        }

        // GET: Waves/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wave wave = db.Waves.Find(id);
            if (wave == null)
            {
                return HttpNotFound();
            }
            return View(wave);
        }

        // POST: Waves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mood,waveID")] Wave wave)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wave).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wave);
        }

        // GET: Waves/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wave wave = db.Waves.Find(id);
            if (wave == null)
            {
                return HttpNotFound();
            }
            return View(wave);
        }

        // POST: Waves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wave wave = db.Waves.Find(id);
            db.Waves.Remove(wave);
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
