﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Toastmaster.Web.Console.Models;
using Toastmaster.Web.Console.Models.ViewModels;
using PagedList;

namespace Toastmaster.Web.Console.Controllers
{
    public class MeetingsController : Controller
    {
        private static readonly int PAGE_SIZE = 5;

        private ToastmasterContext _db = new ToastmasterContext();
        private IMapper _mapper = MvcApplication.MapperConfig.CreateMapper();

        // GET: Meetings
        public ActionResult Index(string sortParam, string currentFilter, string searchString, int? currentPageNum)
        {
            ViewBag.CurrentSortParam = string.IsNullOrEmpty(sortParam) ? ViewBag.CurrentSortParam : sortParam;
            ViewBag.ClubSortParam = sortParam == "Club" ? "ClubDesc" : "Club";
            ViewBag.SeqSortParam = sortParam == "Seq" ? "SeqDesc" : "Seq";
            ViewBag.HoldDateSortParam = sortParam == "HoldDate" ? "HoldDateDesc" : "HoldDate";

            var meetings = _db.Meetings.Include(m => m.Club).AsEnumerable();
            var vms = _mapper.Map<IEnumerable<Meeting>, IEnumerable<MeetingViewModel>>(meetings);

            if (!string.IsNullOrEmpty(searchString))
            {
                currentPageNum = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            if(!string.IsNullOrEmpty(searchString))
            {
                vms = vms.Where(vm => vm.Theme.Contains(searchString));
            }

            switch (sortParam)
            {
                case "Club":
                    vms = vms.OrderBy(vm => vm.ClubId);
                    break;
                case "ClubDesc":
                    vms = vms.OrderByDescending(vm => vm.ClubId);
                    break;
                case "Seq":
                    vms = vms.OrderBy(vm => vm.Seq);
                    break;
                case "SeqDesc":
                    vms = vms.OrderByDescending(vm => vm.Seq);
                    break;
                case "HoldDate":
                    vms = vms.OrderBy(vm => vm.HoldDate);
                    break;
                default:
                    vms = vms.OrderByDescending(vm => vm.HoldDate);
                    break;
            }

            return View(vms.ToPagedList(currentPageNum ?? 1, PAGE_SIZE));
        }

        // GET: Meetings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meeting meeting = _db.Meetings.Find(id);
            if (meeting == null)
            {
                return HttpNotFound();
            }
            return View(meeting);
        }

        // GET: Meetings/Create
        public ActionResult Create()
        {
            ViewBag.ClubId = new SelectList(_db.Clubs, "Id", "Name");
            MeetingViewModel vm = new MeetingViewModel();
            vm.ClubCombobox = new ClubComboboxViewModel();
            vm.ClubCombobox.Clubs = _mapper.Map<IEnumerable<Club>, IEnumerable<ClubViewModel>>(_db.Clubs);
            return View(vm);
        }

        // POST: Meetings/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MeetingViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var meeting = _mapper.Map<MeetingViewModel, Meeting>(vm);
                _db.Meetings.Add(meeting);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            vm.ClubCombobox.Clubs = _mapper.Map<IEnumerable<Club>, IEnumerable<ClubViewModel>>(_db.Clubs);

            return View(vm);
        }

        // GET: Meetings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meeting meeting = _db.Meetings.Find(id);
            if (meeting == null)
            {
                return HttpNotFound();
            }

            var vm = _mapper.Map<Meeting, MeetingViewModel>(meeting);
            vm.ClubCombobox.Clubs = _mapper.Map<IEnumerable<Club>, IEnumerable<ClubViewModel>>(_db.Clubs);

            return View(vm);
        }

        // POST: Meetings/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MeetingViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var updatedMeeting = _mapper.Map<Meeting>(vm);
                _db.Entry(updatedMeeting).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            vm.ClubCombobox.Clubs = _mapper.Map<IEnumerable<Club>, IEnumerable<ClubViewModel>>(_db.Clubs);

            return View(vm);
        }

        // GET: Meetings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meeting meeting = _db.Meetings.Find(id);
            if (meeting == null)
            {
                return HttpNotFound();
            }
            return View(meeting);
        }

        // POST: Meetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Meeting meeting = _db.Meetings.Find(id);
            _db.Meetings.Remove(meeting);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
