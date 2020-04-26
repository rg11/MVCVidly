using AutoMapper;
using System;
using System.Collections.Generic;
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

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // Get api/customers/1
        public IHttpActionResult GetCustomer(int Id)
        {
            Customer customer = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

           
            return Ok(Mapper.Map<Customer,CustomerDto>(customer));
        }

        // Get api/customers
        public IHttpActionResult GetCustomers()
        {
             var customers = _context.Customers.ToList().Select(Mapper.Map <Customer,CustomerDto>);

            
            if (customers == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Ok(customers);
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
