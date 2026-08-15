using EmpManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace EmpManager.Controllers
{
    public class EmployeeController : Controller
    {
        private static List<Employee> employees = new List<Employee>
       {
           new Employee{Id=1,Name="Ravi",Department="IT",Salary=50000},
           new Employee{Id=2,Name="Priya",Department="HR",Salary=45000},
           new Employee{Id=3,Name="Ameer",Department="Finance",Salary=60000}
       };
        public IActionResult Index()
        {
            return View(employees);
        
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            employee.Id = employees.Count + 1;
            employees.Add(employee);
            return RedirectToAction("Index");
        }
        // GET: Employee/Edit/5
        public IActionResult Edit(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            var emp = employees.FirstOrDefault(e => e.Id == employee.Id);
            if (emp != null)
            {
                emp.Name = employee.Name;
                emp.Department = employee.Department;
                emp.Salary = employee.Salary;
            }
            return RedirectToAction("Index");
        }

        // GET: Employee/Delete/5
        public IActionResult Delete(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            employees.Remove(employee);
            return RedirectToAction("Index");
        }
    }
}
