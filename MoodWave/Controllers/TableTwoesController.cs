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
    public class TableTwoesController : Controller
    {
        private MoodWaveEntities db = new MoodWaveEntities();

        // GET: TableTwoes
        public ActionResult Index()
        {
            return View(db.TableTwoes.ToList());
        }

        // GET: TableTwoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableTwo tableTwo = db.TableTwoes.Find(id);
            if (tableTwo == null)
            {
                return HttpNotFound();
            }
            return View(tableTwo);
        }

        // GET: TableTwoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TableTwoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,StaticEmotions,Track,Artist,Username")] TableTwo tableTwo)
        {
            if (ModelState.IsValid)
            {
                db.TableTwoes.Add(tableTwo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tableTwo);
        }

        // GET: TableTwoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableTwo tableTwo = db.TableTwoes.Find(id);
            if (tableTwo == null)
            {
                return HttpNotFound();
            }
            return View(tableTwo);
        }

        // POST: TableTwoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,StaticEmotions,Track,Artist,Username")] TableTwo tableTwo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tableTwo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tableTwo);
        }

        // GET: TableTwoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableTwo tableTwo = db.TableTwoes.Find(id);
            if (tableTwo == null)
            {
                return HttpNotFound();
            }
            return View(tableTwo);
        }

        // POST: TableTwoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TableTwo tableTwo = db.TableTwoes.Find(id);
            db.TableTwoes.Remove(tableTwo);
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
