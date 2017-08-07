using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoodWave.Models;

namespace MoodWave.Controllers
{
    public class TableOnesController : Controller
    {
        private MoodWaveEntities db = new MoodWaveEntities();

        // GET: TableOnes
        public ActionResult Index()
        {
            return View(db.TableOnes.ToList());
        }

        // GET: TableOnes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableOne tableOne = db.TableOnes.Find(id);
            if (tableOne == null)
            {
                return HttpNotFound();
            }
            return View(tableOne);
        }

        // GET: TableOnes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TableOnes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Username,Password")] TableOne tableOne)
        {
            if (ModelState.IsValid)
            {
                db.TableOnes.Add(tableOne);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tableOne);
        }

        // GET: TableOnes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableOne tableOne = db.TableOnes.Find(id);
            if (tableOne == null)
            {
                return HttpNotFound();
            }
            return View(tableOne);
        }

        // POST: TableOnes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Username,Password")] TableOne tableOne)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tableOne).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tableOne);
        }

        // GET: TableOnes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableOne tableOne = db.TableOnes.Find(id);
            if (tableOne == null)
            {
                return HttpNotFound();
            }
            return View(tableOne);
        }

        // POST: TableOnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TableOne tableOne = db.TableOnes.Find(id);
            db.TableOnes.Remove(tableOne);
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
