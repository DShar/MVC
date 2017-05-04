using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVC.Models
{
    public class DbInitializer :DropCreateDatabaseAlways<StaffContext>
    {
        protected override void Seed(StaffContext context)
        {
            context.Employees.Add(new Employee { LastName = "Толстой", FirstName = "Лев", MiddleName = "Николаевич", YearOfBirth = 1828, Gender = "мужской" ,Departmentid = 1});
            context.Employees.Add(new Employee { LastName = "Шекспир", FirstName = "Уильям", MiddleName = " ", YearOfBirth = 1564, Gender = "мужской", Departmentid = 3 });
            context.Employees.Add(new Employee { LastName = "Джойс", FirstName = "Джеймс", MiddleName = " ", YearOfBirth = 1882, Gender = "мужской", Departmentid = 2 });
            context.Employees.Add(new Employee { LastName = "Набоков", FirstName = "Владимир", MiddleName = "Владимирович", YearOfBirth = 1899, Gender = "мужской", Departmentid = 1 });
            context.Employees.Add(new Employee { LastName = "Достоевский", FirstName = "Фёдор", MiddleName = "Михайлович", YearOfBirth = 1821, Gender = "мужской", Departmentid = 1 });
            context.Employees.Add(new Employee { LastName = "Остин", FirstName = "Джейн", MiddleName = " ", YearOfBirth = 1775, Gender = "женский", Departmentid = 3 });

            context.Departments.Add(new Department { Name = "Русская литература" });
            context.Departments.Add(new Department { Name = "Ирландская литература" });
            context.Departments.Add(new Department { Name = "Английская литература" });

            context.Positions.Add(new Position { Name = "Прозаик" });
            context.Positions.Add(new Position { Name = "Драматург" });


            base.Seed(context);
        }
    }
}