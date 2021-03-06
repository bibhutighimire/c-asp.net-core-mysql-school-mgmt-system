﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
	[Table("tblStudent")]
    public class Student
    {
		[Display(Name = "Student ID")]
		public int studentid { get; set; }
		[Required(ErrorMessage = "First Name Required")]
		[Display(Name = "First Name")]
		public string firstname { get; set; }
		[Required(ErrorMessage = "Last Name Required")]
		[Display(Name = "Last Name")]
		public string lastname { get; set; }
		[Required(ErrorMessage = "DOB Required")]
		[Display(Name = "Date of Birth")]
		[DataType(DataType.Date)]
		public DateTime dob { get; set; }
		[Required(ErrorMessage = "Email Required")]
		[Display(Name = "Email")]
		[DataType(DataType.EmailAddress)]
		public string email { get; set; }
		public int positionid { get; set; }
		[Required(ErrorMessage = "Username Required")]
		[Display(Name = "Username")]
		public string username { get; set; }
		[Required(ErrorMessage = "Password Required")]
		[Display(Name = "Password")]
		[DataType(DataType.Password)]
		public string password { get; set; }
		[Required(ErrorMessage = "Grade Required")]
		[Display(Name = "Grade")]
		public string grade { get; set; }
		
	}
}
