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
    public class TeachersController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();

        public ActionResult SaveTeacher()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode");
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationId", "DesignationName");
            return View();
        }

        public JsonResult IsDeptCodeExists(string departmentCode)
        {
            var dept = db.Departments.ToList();
            if (dept.All(x => x.DepartmentCode.ToLower() != departmentCode.ToLower()))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        public JsonResult IsEmailExists(string teacherEmail)
        {
            var teachers = db.Teachers.ToList();
            if (teachers.All(x => x.TeacherEmail.ToLower() != teacherEmail.ToLower()))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveTeacher([Bind(Include = "TeacherId,TeacherName,Address,TeacherEmail,ContactNo,DesignationId,DepartmentId,TeacherCredit")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Teachers.Add(teacher);
                db.SaveChanges();
                FlashMessage.Confirmation("Teacher Saved Successfully");
                return RedirectToAction("SaveTeacher");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode", teacher.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationId", "DesignationName", teacher.DesignationId);
            return View(teacher);
        }
        
    }
}
