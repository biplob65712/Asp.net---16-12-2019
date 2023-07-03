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
    public class StudentsController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();

        public ActionResult ViewStudent()
        {
            var students = db.Students.Include(s => s.Department);
            return View(students.ToList());
        }
        
        public ActionResult SaveStudent()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveStudent([Bind(Include = "StudentId,StudentName,StudentEmail,ContactNo,Date,Address,DepartmentId")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                FlashMessage.Confirmation("Student Registered Successfully");
                return RedirectToAction("SaveStudent");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode", student.DepartmentId);
            return View(student);
        }
        public JsonResult IsEmailExists(string studentEmail)
        {
            var students = db.Students.ToList();
            if (students.All(x => x.StudentEmail.ToLower() != studentEmail.ToLower()))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}
