using LayeredMvcDemo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredMvcDemo.DataAccess
{
    public interface ICustomerRepository
    {
        Customer GetCustomerById(int id);

        IEnumerable<Customer> GetCustomerList(Func<Customer, bool> filter);
    }
}
