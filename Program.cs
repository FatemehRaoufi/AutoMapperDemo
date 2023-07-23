using AutoMapperDemo;
using System.Xml.Serialization;
using static AutoMapperDemo.ConditionalMapping;
using static AutoMapperDemo.FixedDynamicValues;
using static AutoMapperDemo.ReverseMapping;

namespace AutoMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            //SimpleAutoMapper();
            //MapperForMemberMethod();
            //AutomapperwithNestedTypesMethod();
            //AutoMapperReverseMappingMethod1();
            //AutoMapperReverseMappingMethod2();
            // AutoMapperConditionalMappingMethod();
            // AutoMapperUsingIgnoreMethod();
            // AutoMapperFixedDynamicValuesMethod();
            AutpMapperUsingNullSubstituteMethod();

        }
        //-------------------------------------------------
        /// <summary>
        /// //Sample1 Mapping:
        /// </summary>
        public static void SimpleAutoMapper()
        {

            //Create and Populate Employee Object
            Employee emp = new Employee
            {
                Name = "James",
                Salary = 20000,
                Address = "London",
                Department = "IT",

            };

            //way1:Mapping Object in Traditional Approach in C#:
            //Mapping Employee Object to EmployeeDTO Object
            EmployeeDTO empDTO = new EmployeeDTO
            {
                Name = emp.Name,
                Salary = emp.Salary,
                Address = emp.Address,
                Department = emp.Department
            };

            Console.WriteLine("Name:" + empDTO.Name + ", Salary:" + empDTO.Salary + ", Address:" + empDTO.Address + ", Department:" + empDTO.Department);
            Console.ReadLine();


            //Way2:Using AutoMapper:


            //Initializing AutoMapper
            var mapper = MapperConfig.InitializeAutomapper();

            //Way1: Specify the Destination Type and to The Map Method pass the Source Object
            //Now, empDTO1 object will having the same values as emp object
            var empDTO1 = mapper.Map<EmployeeDTO>(emp);

            //Way2: Specify the both Source and Destination Type 
            //and to The Map Method pass the Source Object
            //Now, empDTO2 object will having the same values as emp object
            var empDTO2 = mapper.Map<Employee, EmployeeDTO>(emp);
            //  Console.WriteLine("Name: " + empDTO.Name + ", Salary: " + empDTO.Salary + ", Address: " + empDTO.Address + ", Department: " + empDTO.Department);
            //------------------------------------------------------------------------------------
        }
        /// <summary>
        ///  //Sample2: AutoMapper using 'For Member'
        /// </summary>
        public static void MapperForMemberMethod()
        {

            Employee emp = new Employee
            {
                Name = "James",
                Salary = 20000,
                Address = "London",
                Department = "IT",

            };

            var mapper3 = MapperConfigUsingForMember.InitializeAutomapper();
            var empDTOForMember = mapper3.Map<Employee, EmployeeDTOUsingForMember>(emp);
            Console.WriteLine("NameForMember: " + empDTOForMember.FullName + ", SalaryForMember: " + empDTOForMember.Salary + ", AddressForMember: " + empDTOForMember.Address + ", DepartmentForMember: " + empDTOForMember.Dept);

            Console.ReadLine();


        }
        //------------------------------------------------------------
        /// <summary>
        /// Sample3:Automapper with Nested Types
        /// </summary>
        public static void AutomapperwithNestedTypesMethod()
        {

            //Creating and Instance of Address Entity

            Address empAddres = new Address()
            {
                City = "Mumbai",
                State = "Maharashtra",
                Country = "India"
            };
            //Creating and Instance of Employee Entity
            EmployeeWithNestedAddress emp3 = new EmployeeWithNestedAddress
            {
                Name = "James",
                Salary = 20000,
                Department = "IT",
                Address = empAddres
            };
            //Initialize the AutoMapper
            var mapper3 = MapperConfigForNested.InitializeAutomapper();
            //Way1: Mapping emp Object with EmployeeDTO Object
            var empDTONestedAddress = mapper3.Map<EmployeeDTOWithNestedAddres>(emp3);

            Console.WriteLine("NameNestedType:" + empDTONestedAddress.Name + ", SalaryNestedType:" + empDTONestedAddress.Salary + ", DepartmentNestedType:" + empDTONestedAddress.Department);
            Console.WriteLine("CityNestedType:" + empDTONestedAddress.Address.City + ", StateNestedType:" + empDTONestedAddress.Address.State + ", CountryNestedType:" + empDTONestedAddress.Address.Country);
            Console.ReadLine();
        }
        //------------------------
        /// <summary>
        /// Sample4: Using AutoMapper Reverse Mapping in C#:
        ///The Automapper Reverse Mapping is nothing but Two-Way mapping which is also called Bidirectional Mapping.
        ///As of now, the mapping we discussed is One-Directional Mapping. 
        ///That means if we have two types let’s say Type A and Type B, then we Map Type A with Type B. 
        ///But using Automapper Reverse mapping it is also possible to Map Type B with Type A.

        /// </summary>
        public static void AutoMapperReverseMappingMethod1()
        {
            //Step1: Initialize the Mapper
            var mapper = MapperConfigUsingReverseMap1.InitializeAutomapper();
            //Step2: Create the Order Request
            OrderWithNestedCustomer OrderRequest = CreateOrderRequest();
            //Step3: Map the OrderRequest object with OrderDTO Object
            var orderDTOData = mapper.Map<OrderWithNestedCustomer, OrderDTOWithCustomerFields>(OrderRequest);
            //or
            //var orderDTOData = mapper.Map<OrderDTO>(OrderRequest);
            //Step4: Print the OrderDTO Data
            Console.WriteLine("After Mapping - OrderDTO Data");
            Console.WriteLine("OrderId : " + orderDTOData.OrderId);
            Console.WriteLine("NumberOfItems : " + orderDTOData.NumberOfItems);
            Console.WriteLine("TotalAmount : " + orderDTOData.TotalAmount);
            Console.WriteLine("CustomerId : " + orderDTOData.CustomerId);
            Console.WriteLine("Name : " + orderDTOData.Name);
            Console.WriteLine("Postcode : " + orderDTOData.Postcode);
            Console.WriteLine("MobileNo : " + orderDTOData.MobileNo);
            Console.WriteLine();
            //Step5: modify the OrderDTO data
            orderDTOData.OrderId = 10;
            orderDTOData.NumberOfItems = 20;
            orderDTOData.TotalAmount = 2000;
            orderDTOData.CustomerId = 5;
            orderDTOData.Name = "Smith";
            orderDTOData.Postcode = "12345";
            //Step6: AutoMapper Reverse Mapping
            mapper.Map(orderDTOData, OrderRequest);
            //Step7: Print Order Data
            Console.WriteLine("After Reverse Mapping - Order Data");
            Console.WriteLine("OrderNo : " + OrderRequest.OrderNo);
            Console.WriteLine("NumberOfItems : " + OrderRequest.NumberOfItems);
            Console.WriteLine("TotalAmount : " + OrderRequest.TotalAmount);
            Console.WriteLine("CustomerId : " + OrderRequest.Customer.CustomerID);
            Console.WriteLine("FullName : " + OrderRequest.Customer.FullName);
            Console.WriteLine("Postcode : " + OrderRequest.Customer.Postcode);
            Console.WriteLine("ContactNo : " + OrderRequest.Customer.ContactNo);
            Console.ReadLine();
        }
        private static OrderWithNestedCustomer CreateOrderRequest()
        {
            return new OrderWithNestedCustomer
            {
                OrderNo = 101,
                NumberOfItems = 3,
                TotalAmount = 1000,
                Customer = new Customer()
                {
                    CustomerID = 777,
                    FullName = "James Smith",
                    Postcode = "755019",
                    ContactNo = "1234567890"
                },
            };
        }
        //------------------------------------------------------------------
        public static void AutoMapperReverseMappingMethod2()
        {
            //Step1: Initialize the Mapper
            var mapper = MapperConfigUsingReverseMap2.InitializeAutomapper();

            //Step2: Create the Order Request
            var OrderRequest = CreateOrderRequest2();

            //Step3: Map the OrderRequest object to Order DTO
            var orderDTOData = mapper.Map<OrderWithCustomerFields, OrderDTOWithNestedCustomer>(OrderRequest);

            //Step4: Print the OrderDTO Data
            Console.WriteLine("After Mapping - OrderDTO Data");
            Console.WriteLine("OrderId : " + orderDTOData.OrderId);
            Console.WriteLine("NumberOfItems : " + orderDTOData.NumberOfItems);
            Console.WriteLine("TotalAmount : " + orderDTOData.TotalAmount);
            Console.WriteLine("CustomerId : " + orderDTOData.Customer.CustomerID);
            Console.WriteLine("FullName : " + orderDTOData.Customer.FullName);
            Console.WriteLine("Postcode : " + orderDTOData.Customer.Postcode);
            Console.WriteLine("ContactNo : " + orderDTOData.Customer.ContactNo);
            Console.WriteLine();
            //Step5: modify the OrderDTO data
            orderDTOData.OrderId = 10;
            orderDTOData.NumberOfItems = 20;
            orderDTOData.TotalAmount = 2000;
            orderDTOData.Customer.CustomerID = 5;
            orderDTOData.Customer.FullName = "Pranaya Rout";
            orderDTOData.Customer.Postcode = "12345";
            orderDTOData.Customer.ContactNo = "0011220034";
            //Step6: Reverse Mapping
            mapper.Map(orderDTOData, OrderRequest);
            //Step7: Print the Order Data
            Console.WriteLine("After Reverse Mapping - Order Data");
            Console.WriteLine("OrderNo : " + OrderRequest.OrderNo);
            Console.WriteLine("NumberOfItems : " + OrderRequest.NumberOfItems);
            Console.WriteLine("TotalAmount : " + OrderRequest.TotalAmount);
            Console.WriteLine("\nCustomerId : " + OrderRequest.CustomerId);
            Console.WriteLine("Name : " + OrderRequest.Name);
            Console.WriteLine("Postcode : " + OrderRequest.Postcode);
            Console.WriteLine("MobileNo : " + OrderRequest.MobileNo);
            Console.ReadLine();
        }
        private static OrderWithCustomerFields CreateOrderRequest2()
        {          
               return new OrderWithCustomerFields
               {
                   OrderNo = 101,
                   NumberOfItems = 3,
                   TotalAmount = 1000,
                   CustomerId = 777,
                   Name = "James Smith",
                   Postcode = "755019",
                   MobileNo = "1234567890"
               };
       
        }
        //-----------------------------------
        public static void AutoMapperConditionalMappingMethod()
        {
            var mapper = MapperConfigForConditionalMapping.InitializeAutomapper();
            Product product = new Product()
            {
                ProductID = 101,
                Name = "Led TV",
                OptionalName = "Product name not start with A",
                Quantity = -5,
                Amount = 1000
            };
            var productDTO = mapper.Map<Product, ProductDTO>(product);
            Console.WriteLine("Before Mapping : Product Object");
            Console.WriteLine("ProductID : " + product.ProductID);
            Console.WriteLine("Name : " + product.Name);
            Console.WriteLine("OptionalName : " + product.OptionalName);
            Console.WriteLine("Quantity : " + product.Quantity);
            Console.WriteLine("Amount : " + product.Amount);
            Console.WriteLine();
            Console.WriteLine("After Mapping : ProductDTO Object");
            Console.WriteLine("ProductID : " + productDTO.ProductID);
            Console.WriteLine("ItemName : " + productDTO.ItemName);
            Console.WriteLine("ItemQuantity : " + productDTO.ItemQuantity);
            Console.WriteLine("Amount : " + productDTO.Amount);
            Console.ReadLine();
        }
        //-------------------------------------------------
        public static void AutoMapperUsingIgnoreMethod()
        {
            //Initialize AutoMapper
            var mapper = MapperConfigUsingIgnore.InitializeAutomapper();
            //Creating Source Object
            Employee employee = new Employee()
            {
                ID = 101,
                Name = "James",
                Address = "Mumbai",
                Email = "info@dotnettutorials.net"
            };
            //Mapping Source Employee Object with Destination EmployeeDTO Object
            var empDTO = mapper.Map<Employee, EmployeeDTO>(employee);
            //Printing the Employee Object
            Console.WriteLine("After Mapping : Employee Object");
            Console.WriteLine("ID : " + employee.ID + ", Name : " + employee.Name + ", Address : " + employee.Address + ", Email : " + employee.Email);
            Console.WriteLine();
            //Printing the EmployeeDTO Object
            Console.WriteLine("After Mapping : EmployeeDTO Object");
            Console.WriteLine("ID : " + empDTO.ID + ", Name : " + empDTO.Name + ", Address : " + empDTO.Address + ", Email : " + empDTO.Email);
            Console.ReadLine();
        }
        //-----------------------------------------
        public static void AutoMapperFixedDynamicValuesMethod()
        {
            //Initialize AutoMapper
            var mapper = MapperConfigForFixedDynamicValues.InitializeAutomapper();

            PermanentAddress permAddress = new PermanentAddress()
            {
                Name = "Pranaya",
                Address = "Mumbai"
            };
            var TempAddress = mapper.Map<PermanentAddress, TemporaryAddress>(permAddress);
            Console.WriteLine("After Mapping Permanent Address");
            //Here CreatedBy and CreatedOn will be empty for Permanent Address
            Console.WriteLine($"Name: {permAddress.Name}, Address: {permAddress.Address}, CreatedBy: {permAddress.CreatedBy}, CreatedOn: {permAddress.CreatedOn}");
            Console.WriteLine("After Mapping Permanent Address");
            //Here CreatedBy with Fixed Valye and CreatedOn with Dynamic Value
            Console.WriteLine($"Name: {TempAddress.Name}, Address: {TempAddress.Address}, CreatedBy: {TempAddress.CreatedBy}, CreatedOn: {TempAddress.CreatedOn}");
            Console.ReadLine();
        }
    //----------------------------------
    public static void AutpMapperUsingNullSubstituteMethod()
        {
            //Initialize AutoMapper
            var mapper = MapperConfigUsingNullSubstitute.InitializeAutomapper();
            PermanentAddress permAddress = new PermanentAddress()
            {
                Name = "Pranaya",
                Address = null,
                CreatedBy = "Dot Net Tutorials",
                CreatedOn = DateTime.Now
            };
            var TempAddress = mapper.Map<PermanentAddress, TemporaryAddress>(permAddress);
            Console.WriteLine("After Mapping Permanent Address");
            //Here CreatedBy and CreatedOn will be empty for Permanent Address
            Console.WriteLine($"Name: {permAddress.Name}, Address: {permAddress.Address}, CreatedBy: {permAddress.CreatedBy}, CreatedOn: {permAddress.CreatedOn}");
            Console.WriteLine("After Mapping Permanent Address");
            //Here CreatedBy with Fixed Valye and CreatedOn with Dynamic Value
            Console.WriteLine($"Name: {TempAddress.Name}, Address: {TempAddress.Address}, CreatedBy: {TempAddress.CreatedBy}, CreatedOn: {TempAddress.CreatedOn}");
            Console.ReadLine();
        }
        //------------------------------------------------------
    }
}

//https://dotnettutorials.net/lesson/automapper-in-c-sharp/
//https://dotnettutorials.net/lesson/automapper-with-nested-types/