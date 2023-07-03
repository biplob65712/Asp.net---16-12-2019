using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using FinalProject.Models;

namespace FinalProject.Models
{
    public enum Day
    {
        Sat, Sun, Mon, Tue,Wed,Thu,Fri
    }

    public enum Room
    {
        A101,A102,B201,B202,C301,C302
    }
    public class RoomAllocate
    {
        [Key]
        public int RoomId { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
        public Day Day { get; set; }
        public Room Room { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime  ToTime { get; set; }

    }
}