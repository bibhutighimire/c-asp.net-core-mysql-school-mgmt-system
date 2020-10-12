using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    [Table("tblFee")]
    public class Fee
    {
        public int feeid { get; set; }
        public DateTime datepaid { get; set; }
        public int studentid { get; set; }
        public decimal totalfee { get; set; }
        public decimal paidfee { get; set; }
        
           // public decimal remainingfee { get; set; }
    }
}
