using LayeredMvcDemo.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LayeredMvcDemo.Web
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        public OrderController(IOrderService orderService) 
        {
            this.orderService = orderService;
        }

        public ActionResult Index()
        {
            //var orders = orderService.GetCustomerList(cust => cust.Id < 4);
            //return View(orders);
            return View();
        }
    }
}