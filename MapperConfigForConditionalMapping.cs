using AutoMapper;
using static AutoMapperDemo.ConditionalMapping;

namespace AutoMapperDemo
{
    public class MapperConfigForConditionalMapping
    {
        public static Mapper InitializeAutomapper()
        {
            //Configuring AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>()
                    //If the Name Start with A then Map the Name Value else Map the OptionalName value
                    .ForMember(dest => dest.ItemName, act => act.MapFrom(src =>
                        (src.Name.StartsWith("A") ? src.Name : src.OptionalName)))
                    //Map the quantity value if its greater than 0
                    .ForMember(dest => dest.ItemQuantity, act => act.Condition(src => (src.Quantity > 0)))
                    //Map the amount value if its greater than 100
                    .ForMember(dest => dest.Amount, act => act.Condition(src => (src.Amount > 100)));
            });
            //Creating the Mapper Instance
            var mapper = new Mapper(config);
            //returning the Mapper Instance
            return mapper;
        }
    }
}