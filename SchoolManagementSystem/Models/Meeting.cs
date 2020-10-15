using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    public class Meeting
    {
        public int meetingid { get; set; }
        [Required(ErrorMessage = "Student ID Required")]
        [Display(Name = "Student ID")]
        public int studentid { get; set; }
        [Required(ErrorMessage = "Requested Time Required")]
        [Display(Name = "Requested Time")]
        public DateTime requestedtime { get; set; }
        [Required(ErrorMessage = "Date of Meeting Required")]
        [Display(Name = "Date of Meeting")]
        public DateTime dateofmeeting { get; set; }
        [Required(ErrorMessage = "Time of Meeting Required")]
        [Display(Name = "Time of Meeting")]
        public int meetingtimeid { get; set; }
        [Required(ErrorMessage = "Teacher ID Required")]
        [Display(Name = "Teacher ID")]
        public int teacherid { get; set; }
        [Required(ErrorMessage = "Reason for Meeting Required")]
        [Display(Name = "Reason for Meeting")]

        public string about { get; set; }
        public string status { get; set; }
    }
}
