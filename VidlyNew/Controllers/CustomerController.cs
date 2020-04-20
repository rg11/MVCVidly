using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyNew.Models;
using VidlyNew.ViewModels;

namespace VidlyNew.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new Models.ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();   
        }

        // GET: Customer
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }        

        public ActionResult Details(string Id)
        {
            Customer customer = _context.Customers.Include(
                c => c.MembershipType).
                FirstOrDefault(p => p.Id.ToString() == Id);


            return View(customer);
        }

        public ActionResult New()
        {
            ViewBag.Title = "New Customer";

            var membershipTypes = _context.MembershipTypes.ToList();

            CustomerFormViewModel customerVM = new ViewModels.CustomerFormViewModel
            {
                MembershipTypes  = membershipTypes
            };

            return View("CustomerFormView", customerVM);
        }

        [HttpPost]
        public ActionResult Save(Customer  customer)
        {
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                Customer cusotmerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                cusotmerInDb.Name = customer.Name;
                cusotmerInDb.Birthdate = customer.Birthdate;
                cusotmerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                cusotmerInDb.MembershipTypeId = cusotmerInDb.MembershipTypeId;            
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");            
        }

        public ActionResult Edit(int Id)
        {
            ViewBag.Title = "Edit Customer";

            Customer customer = _context.Customers.SingleOrDefault(c => c.Id == Id);

            CustomerFormViewModel customerVM = new ViewModels.CustomerFormViewModel();

            customerVM.Customer = customer;
            customerVM.MembershipTypes = _context.MembershipTypes;

            return View("CustomerFormView", customerVM);
        }
    }
}