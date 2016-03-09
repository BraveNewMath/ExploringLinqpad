using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console1.Models
{
    public class Product
    {
        public string ProductName { get; set; }
        public Decimal? Price { get; set; }
    }

    public class CategoryWithProduct
    {
        public string Name { get; set; }
        public IEnumerable<Product> Products { get; set; } 
    }
}
