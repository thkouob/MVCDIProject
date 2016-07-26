using LayeredMvcDemo.DataAccess;
using LayeredMvcDemo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredMvcDemo.Application
{
    public class CustomerService : ICustomerService
    {
        //private CustomerRepository repository = new CustomerRepository();
        private readonly ICustomerRepository repository; //change to interface
        public CustomerService(ICustomerRepository repo) //建構式注入
        {
            this.repository = repo;
        }

        public Customer GetCustomerById(int id)
        {
            return repository.GetCustomerById(id);
        }

        public List<Customer> GetCustomerList(Func<Customer, bool> filter)
        {
            return repository.GetCustomerList(filter).ToList();
        }
    }
}
