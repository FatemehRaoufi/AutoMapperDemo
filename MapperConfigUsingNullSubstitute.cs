using AutoMapper;
using static AutoMapperDemo.FixedDynamicValues;

namespace AutoMapperDemo
{
    public class MapperConfigUsingNullSubstitute
    {
        public static Mapper InitializeAutomapper()
        {
            //Configuring AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PermanentAddress, TemporaryAddress>()
                    //Using MapFrom Method to Store Static or Hard-Coded Value in a Destination Property
                    .ForMember(dest => dest.CreatedBy, act => act.MapFrom(src => "System"))

                   //Using MapFrom Method to Store Dynamic Value in a Destination Property
                   //Here, we are calling GetCurrentDateTime method which will return a dynamic value
                   .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => GetCurrentDateTime()))
                   //Storing NA in the destination Address Property, if Source Address is NULL
                   .ForMember(dest => dest.Address, act => act.NullSubstitute("N/A"))
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
    }

    }
//https://dotnettutorials.net/lesson/usevalue-resolveusing-and-null-substitution-using-automapper/