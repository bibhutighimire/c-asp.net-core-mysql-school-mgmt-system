using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
	[Table("tblTranscript")]
    public class Transcript
    {
		[Display(Name = "Transcript ID")]
		public int transcriptid { get; set; }
		
		public int studentid { get; set; }
        public DateTime daterequested { get; set; }
		public string status { get; set; }
	}
}
