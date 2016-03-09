using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console1.Data;
using Console1.Models;

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

        public IEnumerable<CategoryWithProduct> GetProducts(string productNameContains)
        {
            var ctx = new Data.northwindEntities();

            return ctx.Categories
                .Where(c => c.Products.Any(p => p.ProductName.Contains(productNameContains)))
                .Select(c => new Console1.Models.CategoryWithProduct
                {
                    Name = c.CategoryName,
                    Products = c.Products.Where(p => p.ProductName.Contains(productNameContains))
                        .Select(p => new Console1.Models.Product
                        {
                            ProductName = p.ProductName,
                            Price = p.UnitPrice
                        })
                });
        }
    }
}
