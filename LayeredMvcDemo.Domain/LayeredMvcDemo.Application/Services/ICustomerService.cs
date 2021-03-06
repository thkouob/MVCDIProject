﻿using LayeredMvcDemo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredMvcDemo.Application
{
    public interface ICustomerService
    {
        Customer GetCustomerById(int id);
        List<Customer> GetCustomerList(Func<Customer, bool> filter);
    }
}
