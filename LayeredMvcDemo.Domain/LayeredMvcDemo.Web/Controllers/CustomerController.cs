using LayeredMvcDemo.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LayeredMvcDemo.Web
{
    public class CustomerController : Controller
    {
        //private CustomerService customerService = new CustomerService();
        private readonly ICustomerService customerService; //change to use interface
        public CustomerController(ICustomerService service)
        {
            this.customerService = service;
        }
        // GET: Customer
        public ActionResult Index()
        {
            var customers = customerService.GetCustomerList(cust => cust.Id < 4);
            return View(customers);
        }
    }
}