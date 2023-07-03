using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class RoomAllocatesController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();

        public ActionResult ViewClass()
        {
            var roomAllocates = db.RoomAllocates.Include(r => r.Course).Include(r => r.Department);
            return View(roomAllocates.ToList());
        }

        public ActionResult RoomAllocate()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode");
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoomAllocate([Bind(Include = "RoomId,DepartmentId,CourseId,Day,Room,FromTime,ToTime")] RoomAllocate roomAllocate)
        {
            if (ModelState.IsValid)
            {
                db.RoomAllocates.Add(roomAllocate);
                db.SaveChanges();
                return RedirectToAction("RoomAllocate");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode", roomAllocate.CourseId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode", roomAllocate.DepartmentId);
            return View(roomAllocate);
        }
        
    }
}
