using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Please Enter Course Code")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Code Minimum 5 Character Long")]
        [Column(TypeName = "varchar")]
        [Display(Name = "Code")]
        [Remote("IsCourseCodeExists", "Courses", ErrorMessage = "Course  Code Already Exists")]
        public string CourseCode { get; set; }

        [Required(ErrorMessage = "Please Enter Course Name")]
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        [Display(Name = "Name")]
        [Remote("IsCourseNameExists", "Courses", ErrorMessage = "Course Name Already Exists")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Please Enter Course Credit")]
        [Range(0.5, 5.0, ErrorMessage = "0.5 to 5.0")]
        [Column(TypeName = "float")]
        [Display(Name = "Credit")]
        public float Credit { get; set; }

        [Column(TypeName = "varchar")]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        public int SemesterId { get; set; }
        [ForeignKey("SemesterId")]
        public virtual Semester Semester { get; set; }

        [DisplayFormat(NullDisplayText = "Not Assigned Yet")]
        [Remote("IsTeacherAssigned", "Courses", ErrorMessage = "This Teacher Already Assigned")]
        public int? TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}