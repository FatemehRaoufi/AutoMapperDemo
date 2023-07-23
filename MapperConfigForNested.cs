using AutoMapper;
namespace AutoMapperDemo
{
    public class MapperConfigForNested
    {
        public static Mapper InitializeAutomapper()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                //Configuring Address and AddressDTO
                cfg.CreateMap<Address, AddressDTO>();
                //Configuring Employee and EmployeeDTO
                cfg.CreateMap<EmployeeWithNestedAddress, EmployeeDTOWithNestedAddres>();
                //Any Other Mapping Configuration ....
            });

            //Create an Instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}