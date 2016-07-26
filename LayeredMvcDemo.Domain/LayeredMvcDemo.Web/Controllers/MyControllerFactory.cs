﻿using LayeredMvcDemo.Application;
using LayeredMvcDemo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LayeredMvcDemo.Web
{
    public class MyControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (string.Equals(controllerName, "customer", StringComparison.OrdinalIgnoreCase))
            {
                //建立相依物件並注入至新建立的controllers
                //var repository = new CustomerRepository();
                var service = new CustomerService();
                var controller = new CustomerController(service);
                return controller;
            }
            else if (string.Equals(controllerName, "order", StringComparison.OrdinalIgnoreCase))
            {
                //var orderRepo = new OrderRepository();
                //var customerRepo = new CustomerRepository();

                var orderService = new OrderService();
                var controller = new OrderController(orderService);
                return controller;
            }

            // 其他不需要特殊處理的controller型別就使用MVC內建的工廠來建立
            return base.CreateController(requestContext, controllerName);
        }

        public override void ReleaseController(IController controller)
        {
            // 需要釋放其他物件資源寫在這裡
            base.ReleaseController(controller);
        }

    }
}