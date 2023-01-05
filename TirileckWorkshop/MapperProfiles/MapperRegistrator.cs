using AutoMapper;

namespace TirileckWorkshop.MapperProfiles;

public static class MapperRegistrator
{
    public static void Register(IServiceCollection services)
    {
        var mapProfiles = new[]
        {
            new DefaultProfile()
        };
        
        var configuration = new MapperConfiguration(x => x.AddProfiles(mapProfiles));
        IMapper mapper = configuration.CreateMapper();

        services.AddSingleton(mapper);
    }
}