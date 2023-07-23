

namespace AutoMapperDemo
{

    public class EmployeeWithNestedAddress
    {
        public string Name { get; set; }
        public int Salary { get; set; }
    
        public string Department { get; set; }

        public Address Address{ get; set; }
    }

}
