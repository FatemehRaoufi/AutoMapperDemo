using AutoMapper;
using static AutoMapperDemo.ReverseMapping;

namespace AutoMapperDemo
{
    public class MapperConfigUsingReverseMap1
    {
        public static Mapper InitializeAutomapper()
        {
            //Configuring AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                //Mapping Order with OrderDTO
                cfg.CreateMap<OrderWithNestedCustomer, OrderDTOWithCustomerFields>()
                    //OrderId is different so map them using For Member
                    .ForMember(dest => dest.OrderId, act => act.MapFrom(src => src.OrderNo))
                    //Customer is a Complex type, so Map Customer to Simple type using For Member
                    .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Customer.FullName))
                    .ForMember(dest => dest.Postcode, act => act.MapFrom(src => src.Customer.Postcode))
                    .ForMember(dest => dest.MobileNo, act => act.MapFrom(src => src.Customer.ContactNo))
                    .ForMember(dest => dest.CustomerId, act => act.MapFrom(src => src.Customer.CustomerID))
                    .ReverseMap(); //Making the Mapping Bi-Directional
            });
            //Creating the Mapper Instance
            var mapper = new Mapper(config);
            //returning the Mapper Instance
            return mapper;
        }
    }
}