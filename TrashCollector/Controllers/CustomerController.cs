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
                context.Customers.Add(customer);
                context.SaveChanges();
                return RedirectToAction("Index");
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
    }
}
