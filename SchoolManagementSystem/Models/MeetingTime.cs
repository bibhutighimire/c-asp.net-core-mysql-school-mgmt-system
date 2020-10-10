using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    [Table("tblMeetingTime")]
    public class MeetingTime
    {
        public int meetingtimeid { get; set; }
        public string timeslot { get; set; }
    }
}
