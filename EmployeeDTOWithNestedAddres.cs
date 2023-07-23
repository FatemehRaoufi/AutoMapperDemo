

namespace AutoMapperDemo
{
    public class EmployeeDTOWithNestedAddres
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Department { get; set; }

        public AddressDTO Address { get; set; }
    }

}
