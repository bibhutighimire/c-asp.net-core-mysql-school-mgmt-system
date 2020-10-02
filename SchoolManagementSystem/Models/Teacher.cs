using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    [Table("tblTeacher")]
    public class Teacher
    {

        public int teacherid { get; set; }
		public string firstname { get; set; }
		public string lastname { get; set; }
		public DateTime dob { get; set; }
		public string email { get; set; }
		public int positionid { get; set; }
		public string username { get; set; }
		public string password { get; set; }
		public int coursenameid { get; set; }
		
	}
}
