using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    [Table("tblCoursename")]
    public class Coursename
    {
    [Key]
        public int coursenameid { get; set; }
        public string coursename { get; set; }
        public int teacherid { get; set; }

        //public Teacher teacherids { get; set; }
    }
}
