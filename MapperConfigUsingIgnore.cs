using AutoMapper;
namespace AutoMapperDemo
{  
    public class MapperConfigUsingIgnore
    {
        public static Mapper InitializeAutomapper()
        {
            //Configuring AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>()
                    //Ignoring the Address property of the destination type
                    .ForMember(dest => dest.Address, act => act.Ignore());
            });
            //Creating the Mapper Instance
            var mapper = new Mapper(config);
            //returning the Mapper Instance
            return mapper;
        }
    }
}
//https://dotnettutorials.net/lesson/ignore-using-automapper-in-csharp/