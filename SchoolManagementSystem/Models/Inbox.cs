using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    public class Inbox
    {
        public int inboxid { get; set; }
       
        public string subject { get; set; }
        public DateTime datesent { get; set; }
        public int studentid { get; set; }
        public int teacherid { get; set; }
       
    }
}
