using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private static IEnumerable<Customer> customersList()
        {
            var customers = new List<Customer>
            {
                new Customer { Name = "Peter Parker", Id = 1 },
                new Customer { Name = "Tony Stark", Id = 2 }
            };

            return customers;
        }
        

        // GET: Customers
        [Route("customers/")]
        public ActionResult Customers()
        {


            var viewModel = new CustomersViewModel
            {
                Customers = (List<Customer>)customersList()
            };

            return View (viewModel);
        }

        public ActionResult Details(int id)
        {
            var customerDetail = customersList().SingleOrDefault(cus => cus.Id == id);

            if (customerDetail == null)
                return Content("There are no customers!");

            return View(customerDetail);
        }
    }
}