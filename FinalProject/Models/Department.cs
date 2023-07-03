using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }


        [Required(ErrorMessage = "Please Enter Department Code")]
        [StringLength(7, MinimumLength = 2, ErrorMessage = "Code Must Be 2-7 Character Long")]
        [Column(TypeName = "varchar")]
        [Display(Name = "Code")]
        [Remote("IsDeptCodeExists", "Departments", ErrorMessage = "Department Code Already Exists")]
        public string DepartmentCode { get; set; }


        [Required(ErrorMessage = "Please Enter Department Name")]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Display(Name = "Name")]
        [Remote("IsDeptNameExists", "Departments", ErrorMessage = "Department Name Already Exists")]
        public string DepartmentName { get; set; }
    }
}