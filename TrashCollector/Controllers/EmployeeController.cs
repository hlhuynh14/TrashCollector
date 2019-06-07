﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class EmployeeController : Controller
    {
        ApplicationDbContext context;
        public EmployeeController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Employee
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            Employee employee = context.Employees.Where(c => c.ApplicationId == userId).SingleOrDefault();
            int dayEnum = (int)System.DateTime.Now.DayOfWeek;
            string dayString = GetDay(dayEnum);
            var customerList = context.Customers.Where(c => c.pickUpDay == dayString && c.zipcode == employee.zipcode).ToList();

            return View(customerList);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            Employee employee = new Employee();
            return View(employee);
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                // TODO: Add insert logic here
                string employeeFK = User.Identity.GetUserId();
                employee.ApplicationId = employeeFK;
                context.Employees.Add(employee);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public string GetDay(int day)
        {
            string dayinstring = "";
            switch (day)
            {
                case 0:
                    dayinstring = "Sunday";
                    return dayinstring;
                case 1:
                    dayinstring = "Monday";
                    return dayinstring;
                case 2:
                    dayinstring = "Tuesday";
                    return dayinstring;
                case 3:
                    dayinstring = "Wednesday";
                    return dayinstring;
                case 4:
                    dayinstring = "Thursday";
                    return dayinstring;
                case 5:
                    dayinstring = "Friday";
                    return dayinstring;
                case 6:
                    dayinstring = "Saturday";
                    return dayinstring;
                default:
                    return dayinstring;         
            }
                
        }
    }
}
