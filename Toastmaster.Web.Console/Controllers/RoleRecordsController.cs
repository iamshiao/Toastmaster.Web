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
    public class RoleRecordsController : Controller
    {
        private ToastmasterContext db = new ToastmasterContext();

        // GET: RoleRecords
        public ActionResult Index()
        {
            var roleRecords = db.RoleRecords.Include(r => r.Meeting).Include(r => r.Member).Include(r => r.Role);
            return View(roleRecords.ToList());
        }

        // GET: RoleRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleRecord roleRecord = db.RoleRecords.Find(id);
            if (roleRecord == null)
            {
                return HttpNotFound();
            }
            return View(roleRecord);
        }

        // GET: RoleRecords/Create
        public ActionResult Create()
        {
            ViewBag.MeetingId = new SelectList(db.Meetings, "Id", "Theme");
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name");
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name");
            return View();
        }

        // POST: RoleRecords/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,MeetingId,MemberId,RoleId")] RoleRecord roleRecord)
        {
            if (ModelState.IsValid)
            {
                db.RoleRecords.Add(roleRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MeetingId = new SelectList(db.Meetings, "Id", "Theme", roleRecord.MeetingId);
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", roleRecord.MemberId);
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name", roleRecord.RoleId);
            return View(roleRecord);
        }

        // GET: RoleRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleRecord roleRecord = db.RoleRecords.Find(id);
            if (roleRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.MeetingId = new SelectList(db.Meetings, "Id", "Theme", roleRecord.MeetingId);
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", roleRecord.MemberId);
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name", roleRecord.RoleId);
            return View(roleRecord);
        }

        // POST: RoleRecords/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,MeetingId,MemberId,RoleId")] RoleRecord roleRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roleRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MeetingId = new SelectList(db.Meetings, "Id", "Theme", roleRecord.MeetingId);
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", roleRecord.MemberId);
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name", roleRecord.RoleId);
            return View(roleRecord);
        }

        // GET: RoleRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleRecord roleRecord = db.RoleRecords.Find(id);
            if (roleRecord == null)
            {
                return HttpNotFound();
            }
            return View(roleRecord);
        }

        // POST: RoleRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoleRecord roleRecord = db.RoleRecords.Find(id);
            db.RoleRecords.Remove(roleRecord);
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
