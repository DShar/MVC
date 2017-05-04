using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using System.Data.Entity;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        StaffContext db = new StaffContext();

        public ActionResult EmployeesList()
        {
            var employees = db.Employees.Include(p => p.Department);
            return View(employees.ToList());
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AutocompleteSearch(string term)
        {
            var employees = db.Employees.Where(a => a.LastName.Contains(term)).ToList().Select(a => new { value = a.LastName }).Distinct();

            return Json(employees, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult EditEmployee(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            
            Employee employee = db.Employees.Find(id);
            if (employee != null)
            {
                SelectList gender = new SelectList(new[] { "мужской", "женский" });
                SelectList departments = new SelectList(db.Departments, "Id", "Name");
                ViewBag.Departments = departments;
                return View(employee);
            }
            return RedirectToAction("EmployeesList");
        }
        [HttpPost]
        public ActionResult EditEmployee(Employee employee)
        {
            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("EmployeesList");
        }

        [HttpGet]
        public ActionResult Create()
        {
            SelectList gender = new SelectList(new[] { "мужской", "женский" });
            SelectList departments = new SelectList(db.Departments, "Id", "Name");
            ViewBag.Gender = gender;
            ViewBag.Departments = departments;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("EmployeesList");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Employee emp = db.Employees.Find(id);
            if (emp == null)
            {
                return HttpNotFound();
            }

            ViewBag.EmployeeId = id;
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            Employee emp = db.Employees.Find(id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            db.Employees.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("EmployeesList");
        }

        [HttpPost]
        public ActionResult EmployeeSearch(string name)
        {
            var employeesLastName = db.Employees.Where(a => a.LastName.Contains(name)).ToList();
            var employeesFirstName = db.Employees.Where(a => a.FirstName.Contains(name)).ToList();
            if (employeesLastName.Count <= 0 && employeesFirstName.Count <=0)
            {
                return HttpNotFound();
            }
            else
            {
                if(employeesFirstName.Count<=0)
                {
                    return PartialView(employeesLastName);
                }
                else
                {
                    return PartialView(employeesFirstName);
                }
            }
            
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


    }
}