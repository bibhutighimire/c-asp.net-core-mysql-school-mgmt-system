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
        [Display(Name = "Course ID")]
        public int coursenameid { get; set; }
        [Required(ErrorMessage = "Course Name Required")]
        [Display(Name = "Course Name")]
        //[DataType(DataType.EmailAddress)]
        public string coursename { get; set; }
        public int teacherid { get; set; }

        //public virtual Teacher Teacher { get; set; }
        //public Teacher firstname { get; set; }
        //public Teacher lastname { get; set; }

        //public Teacher email { get; set; }
        
    }
}
