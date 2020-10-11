using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    [Table("tblMeetingTime")]
    public class MeetingTime
    {
        
        public int meetingtimeid { get; set; }

        [Required(ErrorMessage = "Time Slot Required")]
        [Display(Name = "Time Slot")]
        public string timeslot { get; set; }
    }
}
