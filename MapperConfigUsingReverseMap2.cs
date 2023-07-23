using AutoMapper;
using static AutoMapperDemo.ReverseMapping;

namespace AutoMapperDemo
{
    public class MapperConfigUsingReverseMap2
    {
        public static Mapper InitializeAutomapper()
        {
            //Configuring AutoMapper
            //Configuring AutoMapper
            var config = new MapperConfiguration(cfg => {
                //Mapping Order with OrderDTO
                cfg.CreateMap<OrderWithCustomerFields, OrderDTOWithNestedCustomer>()
                    .ForMember(dest => dest.OrderId, act => act.MapFrom(src => src.OrderNo))
                    .ForMember(dest => dest.Customer, act => act.MapFrom(src => new Customer()
                    {
                        CustomerID = src.CustomerId,
                        FullName = src.Name,
                        Postcode = src.Postcode,
                        ContactNo = src.MobileNo
                    }))
                    .ReverseMap(); //This will make the Mapping as Bi-Directional
                                   //Now, we can also Map OrderDTO with Order Object
            });
            //Creating the Mapper Instance
            var mapper = new Mapper(config);
            //returning the Mapper Instance
            return mapper;
        }
    }
}