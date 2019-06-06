using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext context;
        public CustomerController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            Customer customer = context.Customers.Where(c => c.id == id).Single();
            return View(customer);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            Customer customer = new Customer();
            return View(customer);
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {

            try
            {
                // TODO: Add insert logic here
                // assign FK
                string customerFK = User.Identity.GetUserId();
                customer.ApplicationId = customerFK;
                context.Customers.Add(customer);
                context.SaveChanges();
                return RedirectToAction("Details");
            }
            catch
            {
                return View();
            }

        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
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

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
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
        public ActionResult SuspendPickup(int id)
        {
            Customer customer = context.Customers.Where(c => c.id == id).Single();
            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult SuspendPickup(int id, Customer oldCustomer)
        {
            try
            {
                // TODO: Add update logic here
                Customer customer = context.Customers.Where(c => c.id == id).Single();
                customer.suspendedStart = oldCustomer.suspendedStart;
                customer.supspendEnd = oldCustomer.supspendEnd;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ChangePickUpDate(int id)
        {
            Customer customer = context.Customers.Where(c => c.id == id).Single();
            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult ChangePickUpDate(int id, Customer oldCustomer)
        {
            try
            {
                // TODO: Add update logic here
                Customer customer = context.Customers.Where(c => c.id == id).Single();
                customer.pickUpDay = oldCustomer.pickUpDay;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult AddOneDayPickUp(int id)
        {
            Customer customer = context.Customers.Where(c => c.id == id).Single();
            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult AddOneDayPickUp(int id, Customer oldCustomer)
        {
            try
            {
                // TODO: Add update logic here
                Customer customer = context.Customers.Where(c => c.id == id).Single();
                customer.oneTimePickUp = oldCustomer.oneTimePickUp;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult UpdateProfile(int id)
        {
            Customer customer = context.Customers.Where(c => c.id == id).Single();
            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult UpdateProfile(int id, Customer oldCustomer)
        {
            try
            {
                // TODO: Add update logic here
                Customer customer = context.Customers.Where(c => c.id == id).Single();
                customer.firstName = oldCustomer.firstName;
                customer.lastName = oldCustomer.lastName;
                customer.address = oldCustomer.address;
                customer.zipcode = oldCustomer.zipcode;
                customer.email = oldCustomer.email;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Cancel()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
