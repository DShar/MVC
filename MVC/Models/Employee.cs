using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Employee
    {
        public int id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public int YearOfBirth { get; set; }

        public string Gender { get; set; }

        public int Position_id { get; set; }

        public int Departmentid { get; set; }

        public Department Department { get; set; }
    }
}