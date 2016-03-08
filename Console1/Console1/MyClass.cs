using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console1
{
    public class MyClass
    {
        public string SayHello()
        {
            var result = "Hello world";
            return result;
        }

        public IEnumerable<string> GetCustomerNames()
        {
            //var ctx = ne
            var ctx= new Data.northwindEntities();
            var customerNames = ctx.Customers
                .Select(c => string.Concat(c.ContactName, " @ ", c.CompanyName));
            return customerNames;
        }
    }
}
