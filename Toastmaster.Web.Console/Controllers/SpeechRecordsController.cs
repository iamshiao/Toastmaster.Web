using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Toastmaster.Web.Console.Models;

namespace Toastmaster.Web.Console.Controllers
{
    public class SpeechRecordsController : Controller
    {
        private ToastmasterContext db = new ToastmasterContext();

        // GET: SpeechRecords
        public ActionResult Index()
        {
            var speechRecords = db.SpeechRecords.Include(s => s.Meeting).Include(s => s.Member);
            return View(speechRecords.ToList());
        }

        // GET: SpeechRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpeechRecord speechRecord = db.SpeechRecords.Find(id);
            if (speechRecord == null)
            {
                return HttpNotFound();
            }
            return View(speechRecord);
        }

        // GET: SpeechRecords/Create
        public ActionResult Create()
        {
            ViewBag.MeetingId = new SelectList(db.Meetings, "Id", "Theme");
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name");
            return View();
        }

        // POST: SpeechRecords/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Project,ProjectSeq,Title,MemberId,MeetingId")] SpeechRecord speechRecord)
        {
            if (ModelState.IsValid)
            {
                db.SpeechRecords.Add(speechRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MeetingId = new SelectList(db.Meetings, "Id", "Theme", speechRecord.MeetingId);
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", speechRecord.MemberId);
            return View(speechRecord);
        }

        // GET: SpeechRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpeechRecord speechRecord = db.SpeechRecords.Find(id);
            if (speechRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.MeetingId = new SelectList(db.Meetings, "Id", "Theme", speechRecord.MeetingId);
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", speechRecord.MemberId);
            return View(speechRecord);
        }

        // POST: SpeechRecords/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Project,ProjectSeq,Title,MemberId,MeetingId")] SpeechRecord speechRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(speechRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MeetingId = new SelectList(db.Meetings, "Id", "Theme", speechRecord.MeetingId);
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", speechRecord.MemberId);
            return View(speechRecord);
        }

        // GET: SpeechRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpeechRecord speechRecord = db.SpeechRecords.Find(id);
            if (speechRecord == null)
            {
                return HttpNotFound();
            }
            return View(speechRecord);
        }

        // POST: SpeechRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SpeechRecord speechRecord = db.SpeechRecords.Find(id);
            db.SpeechRecords.Remove(speechRecord);
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
