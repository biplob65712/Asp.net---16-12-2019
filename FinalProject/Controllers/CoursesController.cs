using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using Vereyon.Web;

namespace FinalProject.Controllers
{
    public class CoursesController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();

        public ActionResult ViewCourse()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode");

            var courses = db.Courses.Include(c => c.Department).Include(c => c.Semester).Include(c => c.Teacher);
            return View(courses.ToList());
        }

        public ActionResult SaveCourse()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode");
            ViewBag.SemesterId = new SelectList(db.Semesters, "SemesterId", "SemesterName");
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCourse([Bind(Include = "CourseId,CourseCode,CourseName,Credit,Description,DepartmentId,SemesterId,TeacherId")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                FlashMessage.Confirmation("Course Saved Successfully");
                return RedirectToAction("SaveCourse");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode", course.DepartmentId);
            ViewBag.SemesterId = new SelectList(db.Semesters, "SemesterId", "SemesterName", course.SemesterId);
            
            return View(course);
        }
        public JsonResult IsCourseCodeExists(string courseCode)
        {
            var courses = db.Courses.ToList();
            if (courses.All(x => x.CourseCode.ToLower() != courseCode.ToLower()))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsCourseNameExists(string courseName)
        {
            var courses = db.Courses.ToList();
            if (courses.All(x => x.CourseName.ToLower() != courseName.ToLower()))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AssignCourse()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode");
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "TeacherName");
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode");

            return View();
        }

        [HttpPost]
        
        public ActionResult AssignCourse([Bind(Include = "TeacherId")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                FlashMessage.Confirmation("Course Assign Successfully");
                return RedirectToAction("AssignCourse");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode", course.DepartmentId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "TeacherName", course.TeacherId);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode",course.CourseCode);


            return View(course);
        }
        public JsonResult IsTeacherAssigned(string teacherName)
        {
            var teacher = db.Courses.ToList();
            if (teacher.All(x => x.Teacher.TeacherName.ToLower() != teacherName.ToLower()))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTeacherByDeptId(int departmentId)
        {
            var teachers = db.Teachers.Where(x => x.DepartmentId == departmentId).ToList();
            return Json(teachers);
        }

        public JsonResult GetTeacherById(int id)
        {
            var teacher = db.Teachers.FirstOrDefault(x => x.TeacherId == id);
            return Json(teacher);
        }
        public JsonResult GetCourseByDeptId(int departmentId)
        {
            var course = db.Courses.Where(x => x.DepartmentId == departmentId).ToList();
            return Json(course);
        }

        public JsonResult GetCourseById(int id)
        {
            var course = db.Courses.FirstOrDefault(x => x.TeacherId == id);
            return Json(course);
        }
    }
}
