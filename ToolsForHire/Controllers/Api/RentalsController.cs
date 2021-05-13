using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToolsForHire.Models;
using ToolsForHire.Dtos;
using AutoMapper;
using System.Data.Entity;

namespace ToolsForHire.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);
            var tools = _context.Tools.Where(t => newRental.ToolIds.Contains(t.Id)).ToList();

            foreach(var tool in tools)
            {
                if (tool.NumberAvailable == 0)
                    return BadRequest("Tool is not available.");

                tool.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Tool = tool,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);

            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
