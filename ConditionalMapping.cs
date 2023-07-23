using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperDemo
{
    internal class ConditionalMapping
    {
        public class Product
        {
            public int ProductID { get; set; }
            public string Name { get; set; }
            public string OptionalName { get; set; }
            public int Quantity { get; set; }
            public int Amount { get; set; }
        }
        public class ProductDTO
        {
            public int ProductID { get; set; }
            public string ItemName { get; set; }
            public int ItemQuantity { get; set; }
            public int Amount { get; set; }
        }
    }
}
//https://dotnettutorials.net/lesson/automapper-conditional-mapping-dotnet/