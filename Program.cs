using AutoMapperDemo;

namespace AutoMapper
{
    class Program
    {
        static void Main(string[] args)
        {

            //Create and Populate Employee Object
            Employee emp = new Employee
            {
                Name = "James",
                Salary = 20000,
                Address = "London",
                Department = "IT"
            };
            /*
             Mapping Object in Traditional Approach in C#:
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
                        */



            //Using AutoMapper:


            //Initializing AutoMapper
            var mapper = MapperConfig.InitializeAutomapper();
            //Way1: Specify the Destination Type and to The Map Method pass the Source Object
            //Now, empDTO1 object will having the same values as emp object
            var empDTO1 = mapper.Map<EmployeeDTO>(emp);

            //Way2: Specify the both Source and Destination Type 
            //and to The Map Method pass the Source Object
            //Now, empDTO2 object will having the same values as emp object
            var empDTO2 = mapper.Map<Employee, EmployeeDTO>(emp);
            Console.WriteLine("Name: " + empDTO1.Name + ", Salary: " + empDTO1.Salary + ", Address: " + empDTO1.Address + ", Department: " + empDTO1.Department);

            var mapper1 = MapperConfigForMember.InitializeAutomapper();
            var empDTO3 = mapper1.Map<Employee, EmployeeDTOForMember>(emp);
            Console.WriteLine("Name2: " + empDTO3.FullName + ", Salary2: " + empDTO3.Salary + ", Address2: " + empDTO3.Address + ", Department2: " + empDTO3.Dept);

            Console.ReadLine();
        }
    }
}

//https://dotnettutorials.net/lesson/automapper-in-c-sharp/