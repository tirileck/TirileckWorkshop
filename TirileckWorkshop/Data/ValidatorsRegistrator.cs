using TirileckWorkshop.Data.Dto;

namespace TirileckWorkshop.Data;

public static class ValidatorsRegistrator
{
    public static void Register(IServiceCollection servicea)
    {
        servicea.AddSingleton<AddOrderShortDtoExtensions.AddOrderShortStoValidator>();
    }
}