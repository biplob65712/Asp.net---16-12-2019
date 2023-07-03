using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Please Enter Student Name")]
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        [Display(Name = "Student Name")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Please Enter Student Email Address")]
        [EmailAddress(ErrorMessage = "Please Enter Correct Format")]
        [Display(Name = "Email Address")]
        [Remote("IsEmailExists", "Students", ErrorMessage = "Email Address Already Exists")]
        public string StudentEmail { get; set; }
        [Required(ErrorMessage = "Please Enter Student Contact No")]
        [StringLength(11)]
        [Column(TypeName = "varchar")]
        [Display(Name = "Contact No")]
        public string ContactNo { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Column(TypeName = "varchar")]
        [Display(Name = "Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
       
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        //public string RegNo
        //{
        //    get { return Department.DepartmentCode + "-" + Date.Year + "-" + StudentId; }
        //}
    }
}