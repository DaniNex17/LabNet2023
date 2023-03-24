using Lab.Net.EF.Logic;
using Lab.Net.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab.Net.MVC.Models;
using Lab.Net.EF.Entities;

namespace Lab.Net.MVC.Controllers
{
    public class EmployeesController : Controller
    {
        readonly EmployeesLogic logic = new EmployeesLogic();
        public ActionResult Index()
        {
            
            List<Lab.Net.EF.Entities.Employees> employees = logic.GetAll(); 
            List<EmployeesView> employeesViews = employees.Select(e => new EmployeesView 
            {
                Id = e.EmployeeID,
                FirstName = e.FirstName,
                LastName = e.LastName,
            }).ToList();
            return View(employeesViews);
        }

        public ActionResult Insert() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(EmployeesView employeesView) 
        {
            if (!ModelState.IsValid)
            {
                return View(employeesView);
            }
            try
            {
                
                Employees employee = new Employees {FirstName = employeesView.FirstName, LastName = employeesView.LastName };
                logic.Add(employee);
                return RedirectToAction("Index"); 
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Delete(int id) 
        {
            logic.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            try
            {
                Employees employee = logic.GetById(id);
                EmployeesView employeeView = new EmployeesView
                {
                    Id = employee.EmployeeID,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                };
                return View(employeeView);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        [HttpPost]
        public ActionResult Update(EmployeesView employeesView)
        {
            if (!ModelState.IsValid)
            {
                return View(employeesView);
            }
            
            try
            {
                Employees employee = logic.GetById(employeesView.Id);
                employee.FirstName = employeesView.FirstName;
                employee.LastName = employeesView.LastName;
                logic.Update(employee);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
}