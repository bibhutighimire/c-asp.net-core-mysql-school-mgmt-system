using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    public class ConnectionDB: DbContext
    {
        public ConnectionDB(DbContextOptions<ConnectionDB> options) : base(options)
        {

        }
        public DbSet<Position> tblPosition { get; set; }
    }
}
