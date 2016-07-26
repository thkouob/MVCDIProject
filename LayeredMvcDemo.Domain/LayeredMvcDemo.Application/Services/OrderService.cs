using LayeredMvcDemo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredMvcDemo.Application
{
    public class OrderService : IOrderService
    {
        //private readonly IOrderRepository orderRepository;
        //private readonly ICustomerRepository customerRepository;

        private readonly SouthwindContext db;
        public OrderService()
        {
            // 提供預設的DbContext 物件。
            db = new SouthwindContext();
        }

        public OrderService(SouthwindContext dbContext)
        {
            //this.orderRepository = orderRepo;
            //this.customerRepository = custRepo;
            this.db = dbContext;
        }

        //public void CreateOrder(Order order)
        //{
        //    // 建立相關服務時一併傳入DbContext 物件。
        //    var customerSvc = new CustomerService(this.db);
        //    var shippingSvc = new ShippingService(this.db);
        //    customerSvc.DoSomething(order);
        //    shippingSvc.DoSomething(order);
        //    db.Orders.Add(order);
        //    db.SaveChanges();
        //}
    }
}
