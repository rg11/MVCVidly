using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using VidlyNew.Dtos;
using VidlyNew.Models;

namespace VidlyNew.Controllers.API
{
    public class CustomersController : ApiController
    {

        ApplicationDbContext _context;
        private readonly object c;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // Get api/customers/1
        public IHttpActionResult GetCustomer(int Id)
        {
            var customer = _context.Customers
                .Include(c => c.MembershipType).SingleOrDefault(c => c.Id == Id);
                                                       
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

           
            return Ok(Mapper.Map<Customer,CustomerDto>(customer));
        }

        // Get api/customers
        public IHttpActionResult GetCustomers()
        {
            var customersQuery = _context.Customers
               .Include(c => c.MembershipType);     

            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
                            
            
            if (customerDtos == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Ok(customerDtos);
        }

        //POST api/customers
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateCustomers(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);

            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(Request.RequestUri+"/"+customerDto.Id, customerDto);
        }


        //Edit api/customers/1
        [System.Web.Http.HttpPut]
        public IHttpActionResult EditCustomer(CustomerDto customerDto)
        {
            if(!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            Customer customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customerDto.Id);

            if(customerInDb==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(customerDto, customerInDb);

            
            _context.SaveChanges();

            return Json(customerDto);

        }

        //Delete api/customers/1
        [System.Web.Http.HttpDelete]
        public IHttpActionResult  DeleteCustomer(int id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            Customer customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(customerInDb);

            _context.SaveChanges();

            return Ok();
                                                
        }
    }
}
