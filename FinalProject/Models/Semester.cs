using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Semester
    {
        [Key]
        public int SemesterId { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Display(Name = "Semester")]
        public string SemesterName { get; set; }
    }
}