using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "Please Enter Teacher Name")]
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        [Display(Name = "Teacher Name")]
        public string TeacherName { get; set; }

        [Column(TypeName = "varchar")]
        [Display(Name = "Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Enter Teacher Email Address")]
        [EmailAddress(ErrorMessage = "Please Enter Correct Format")]
        [Display(Name = "Email Address")]
        [Remote("IsEmailExists", "Teachers", ErrorMessage = "Email Address Already Exists")]
        public string TeacherEmail { get; set; }

        [Required(ErrorMessage = "Please Enter Teacher Contact No")]
        [StringLength(11)]
        [Column(TypeName = "varchar")]
        [Display(Name = "Contact No")]
        public string ContactNo { get; set; }


        public int DesignationId { get; set; }

        [ForeignKey("DesignationId")]

        public virtual Designation Designation { get; set; }


        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]

        public virtual Department Department { get; set; }

        [Required(ErrorMessage = "Please Enter Teacher Credit")]
        [Range(0, 20, ErrorMessage = "Maximum 20")]
        [Column(TypeName = "int")]
        [Display(Name = "Credit to Be Taken")]
        public int TeacherCredit { get; set; }

    }
}