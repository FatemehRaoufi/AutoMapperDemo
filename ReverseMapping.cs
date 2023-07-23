using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperDemo
{
    internal class ReverseMapping
    {
        public ReverseMapping() { }
        public class Customer
        {
            public int CustomerID { get; set; }
            public string FullName { get; set; }
            public string Postcode { get; set; }
            public string ContactNo { get; set; }
        }
        public class OrderWithNestedCustomer
        {
            public int OrderNo { get; set; }
            public int NumberOfItems { get; set; }
            public int TotalAmount { get; set; }
            public Customer Customer { get; set; }

          
        }
        public class OrderDTOWithCustomerFields
        {
            public int OrderId { get; set; }
            public int NumberOfItems { get; set; }
            public int TotalAmount { get; set; }
            public int CustomerId { get; set; }
            public string Name { get; set; }
            public string Postcode { get; set; }
            public string MobileNo { get; set; }


            
        }
        //-----------------------
        public class OrderWithCustomerFields
        {
            public int OrderNo { get; set; }
            public int NumberOfItems { get; set; }
            public int TotalAmount { get; set; }
            public Customer Customer { get; set; }          
            public int CustomerId { get; set; }
            public string Name { get; set; }
            public string Postcode { get; set; }
            public string MobileNo { get; set; }
        }
        //---------------------------------
        public class OrderDTOWithNestedCustomer
        {
            public int OrderId { get; set; }
            public int NumberOfItems { get; set; }
            public int TotalAmount { get; set; }
            public Customer Customer { get; set; }
        }
    }
}
//https://dotnettutorials.net/lesson/reverse-mapping-using-automapper/