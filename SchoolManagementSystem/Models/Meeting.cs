using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    public class Meeting
    {
        public int meetingid { get; set; }
        public int studentid { get; set; }
        public DateTime requestedtime { get; set; }
        public DateTime dateofmeeting { get; set; }
        public int meetingtimeid { get; set; }
        public int teacherid { get; set; }
        public string about { get; set; }
    }
}
