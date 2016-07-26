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
        private readonly IOrderRepository orderRepository;
        private readonly ICustomerRepository customerRepository;

        public OrderService(IOrderRepository orderRepo, ICustomerRepository custRepo)
        {
            this.orderRepository = orderRepo;
            this.customerRepository = custRepo;
        }
    }
}
