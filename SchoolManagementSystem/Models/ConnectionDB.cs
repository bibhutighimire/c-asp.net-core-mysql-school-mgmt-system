using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Models
{
    public class ConnectionDB: DbContext
    {
        public ConnectionDB(DbContextOptions<ConnectionDB> options) : base(options)
        {

        }
        public DbSet<Position> tblPosition { get; set; }
        public DbSet<Coursename> tblCoursename { get; set; }
        public DbSet<Teacher> tblTeacher { get; set; }

        public DbSet<Student> tblStudent { get; set; }

        public DbSet<Admin> tblAdmin { get; set; }
        public DbSet<Transcript> tblTranscript { get; set; }

        public DbSet<MultipleCourseStudent> tblMultipleCourseStudent { get; set; }
        public DbSet<Meeting> tblMeeting { get; set; }
        public DbSet<MeetingTime> tblMeetingTime { get; set; }
        public DbSet<Fee> tblFee { get; set; }
        //public DbSet<SchoolManagementSystem.Models.Signin> Signin { get; set; }

    }
}
