using AutoMapper;
using static AutoMapperDemo.ReverseMapping;

namespace AutoMapperDemo
{
    public class MapperConfigUsingReverseMap3
    {
        /// <summary>
        /// we are also using the ForMember method to map the Complex Type Property of the OrderDTO Object to the Primitive Type Properties of the Order Object.
        /// </summary>
        /// <returns></returns>
        public static Mapper InitializeAutomapper()
        {
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
                    .ReverseMap() //This will make the Mapping as Bi-Directional
                                  //Mappping Complex Type to Primitive Type Properties
                    .ForMember(dest => dest.CustomerId, act => act.MapFrom(src => src.Customer.CustomerID))
                    .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Customer.FullName))
                    .ForMember(dest => dest.MobileNo, act => act.MapFrom(src => src.Customer.ContactNo))
                    .ForMember(dest => dest.Postcode, act => act.MapFrom(src => src.Customer.Postcode));
            });
            //Creating the Mapper Instance
            var mapper = new Mapper(config);
            //returning the Mapper Instance
            return mapper;
        }
    }
    
}