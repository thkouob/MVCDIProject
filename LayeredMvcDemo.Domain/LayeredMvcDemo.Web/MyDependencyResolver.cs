using LayeredMvcDemo.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LayeredMvcDemo.Web
{
    public class MyDependencyResolver : IDependencyResolver
    {
        public object GetService(Type serviceType)
        {
            // 觀察MVC 框架有哪些服務會透過dependency resolver 來解析。
            System.Diagnostics.Debug.WriteLine(serviceType.FullName);

            if (serviceType == typeof(CustomerController)) 
            {
                var customerSvc = new CustomerService();
                var controller = new CustomerController(customerSvc);
                return controller;
            }

            // 不需要在此解析的型別，必須傳回null。（can not throw exception.）
            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            //（can not throw exception.）
            // 沒有特別要解析的型別，故傳回空集合
            return new List<object>();
        }
    }
}