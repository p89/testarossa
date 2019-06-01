using AutoMapper;
using testarossa.Core.Domain;
using testarossa.Infrastructure.DTO;

namespace testarossa.Infrastructure.Mappers
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize() 
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
            })
            .CreateMapper();
            return configuration;
        }
    }
}