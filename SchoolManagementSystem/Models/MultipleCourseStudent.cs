using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    public class MultipleCourseStudent
    {
        public int multiplecoursestudentid { get; set; }
        [Required(ErrorMessage = "Student ID Required")]
        [Display(Name = "Student ID")]
        public int studentid { get; set; }
        [Required(ErrorMessage = "Course Name ID Required")]
        [Display(Name = "Course Name ID")]
        public int coursenameid { get; set; }

    }
}
