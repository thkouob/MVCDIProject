using LayeredMvcDemo.Domain;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LayeredMvcDemo.DataAccess
{
    public class SouthwindContext : DbContext
    {
        public static SouthwindContext InstanceInCurrentRequest 
        {
            get 
            {
                return HttpContext.Current.Items["DbContext"] as SouthwindContext;
            }
        }

        public SouthwindContext()
            : base("SouthwindDB")
        {
            Database.SetInitializer<SouthwindContext>(new SouthwindDBInitializer());
        }

        public DbSet<Customer> Customers { get; set; }

        ////public DbSet<Order> Orders { get; set; }
    }

    public class SouthwindDBInitializer : CreateDatabaseIfNotExists<SouthwindContext>
    {
        public override void InitializeDatabase(SouthwindContext context)
        {
            base.InitializeDatabase(context);

            context.Customers.Add(new Customer
            {
                Id = 1,
                CompanyName = "ThkSoft",
                Contact = "Thkouob"
            });

            context.Customers.Add(new Customer
            {
                Id = 2,
                CompanyName = "OmgCall",
                Contact = "Omg"
            });

            context.Customers.Add(new Customer
            {
                Id = 3,
                CompanyName = "StellaTech",
                Contact = "Stella"
            });

            context.Customers.Add(new Customer
            {
                Id = 4,
                CompanyName = "IoSee",
                Contact = "Mark"
            });

            //context.Orders.Add(new Order
            //{
            //    CartId = 00001,
            //    SONumber = "S1122334",
            //    Item = "9B20-151-qtp"
            //});

            //context.Orders.Add(new Order
            //{
            //    CartId = 00002,
            //    SONumber = "S2233445",
            //    Item = "9B20-100-abc"
            //});

            //context.Orders.Add(new Order
            //{
            //    CartId = 00001,
            //    SONumber = "S3344556",
            //    Item = "9B10-999-qwe"
            //});

            context.SaveChanges();
        }
    }
}
