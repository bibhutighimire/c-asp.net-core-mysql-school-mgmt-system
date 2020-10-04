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
        public DbSet<SchoolManagementSystem.Models.Signin> Signin { get; set; }

    }
}
