using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVC.Models
{
    public class StaffContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Position> Positions { get; set; }
    }
}