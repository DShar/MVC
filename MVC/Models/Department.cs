using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Department
    {
        public int id { get; set; }

        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
        public Department()
        {
            Employees = new List<Employee>();
        }
    }
}