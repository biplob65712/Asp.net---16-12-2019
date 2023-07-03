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
    public class DepartmentsController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();

       
        public ActionResult ViewDepartment()
        {
            return View(db.Departments.ToList());
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

        public JsonResult IsDeptNameExists(string departmentName)
        {
            var dept = db.Departments.ToList();
            if (dept.All(x => x.DepartmentName.ToLower() != departmentName.ToLower()))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveDepartment()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveDepartment([Bind(Include = "DepartmentId,DepartmentCode,DepartmentName")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(department);
                db.SaveChanges();
                FlashMessage.Confirmation("Department Saved Successfully");
                return RedirectToAction("SaveDepartment");
            }

            return View(department);
        }
    }
}
