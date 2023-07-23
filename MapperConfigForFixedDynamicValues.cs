using AutoMapper;
using static AutoMapperDemo.FixedDynamicValues;

namespace AutoMapperDemo
{
    public class MapperConfigForFixedDynamicValues
    {
        public static Mapper InitializeAutomapper()
        {
            //Configuring AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PermanentAddress, TemporaryAddress>()
                    //Using MapFrom Method to Store Static or Hard-Coded Value in a Destination Property
                    .ForMember(dest => dest.CreatedBy, act => act.MapFrom(src => "System"))
                   //Before AutoMapper 8.0, to Store Static Value use the UseValue() method
                   //.ForMember(dest => dest.CreatedBy, act => act.UseValue("System"))
                   //Using MapFrom Method to Store Dynamic Value in a Destination Property
                   //Here, we are calling GetCurrentDateTime method which will return a dynamic value
                   .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => GetCurrentDateTime()))
                   ////Before AutoMapper 8.0, To Store Dynamic value use ResolveUsing() method
                   //.ForMember(dest => dest.CreatedBy, act => act.ResolveUsing(src =>
                   //{
                   //    return DateTime.Now;
                   //}))
                   .ReverseMap();
            });

            //Creating the Mapper Instance
            var mapper = new Mapper(config);
            //returning the Mapper Instance
            return mapper;
        }
        //Method to return Dynamic Value
        public static DateTime GetCurrentDateTime()
        {
            //Write the Logic to Get Dynamic value
            return DateTime.Now;
        }
        //Method to return Dynamic Value
    
    }
    
}
//https://dotnettutorials.net/lesson/usevalue-resolveusing-and-null-substitution-using-automapper/