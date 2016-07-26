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
        //private CustomerRepository repository = new CustomerRepository(); -----v1
        
        //private readonly ICustomerRepository repository; //change to interface -----v2

        private readonly SouthwindContext db;
        public CustomerService()
        {
            // 提供預設的DbContext 物件。
            db = new SouthwindContext();
        }

        public CustomerService(SouthwindContext dbContext)
        {
           // this.repository = repo; ------v2
            // 呼叫端有注入DbContext 物件，就用對方提供的。
            this.db = dbContext;
        }

        public Customer GetCustomerById(int id)
        {
            //return repository.GetCustomerById(id);
            return db.Customers.Find(id);
        }

        public List<Customer> GetCustomerList(Func<Customer, bool> filter)
        {
            //return repository.GetCustomerList(filter).ToList();
            return db.Customers.Where(filter).ToList();
        }
    }
}
