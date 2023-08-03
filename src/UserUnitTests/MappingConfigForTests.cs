using AutoMapper;
using Infrastructure.Users.Mapping;

namespace UserUnitTests;
public static class MappingConfigForTests
{
    public static MapperConfiguration CreateMapperConfig()
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<RoleMapperProfile>();
            cfg.AddProfile<UserMapperProfile>();
        });
    }

    public static IMapper CreateMapper()
    {
        return CreateMapperConfig().CreateMapper();
    }
}
