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
            var membershipTypes = _context.MembershipTypes.ToList();
            NewCustomerViewModel newCustomerVM = new ViewModels.NewCustomerViewModel
            {
                MembershipTypes  = membershipTypes
            };

            return View(newCustomerVM);
        }
    }
}